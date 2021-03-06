using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hive.Projectile
{
    public class ProjectileBase : MonoBehaviour
    {
        private static int counter = 1;
        private int id_;
        public int pId { get { return id_; } }
        [SerializeField]
        private ProjectileStat stats_;
        public ProjectileStat pStatComponent { get { return stats_; } }
        private TowerBase tower_;
        private Vector3 direction_;
        private float current_speed_;
        private Transform target_;
        private float delta_time_;
        private bool is_accelerating_;
        private float acceleration_direction_;
        private Vector3 target_pos_;

        public void Shoot(Transform target, TowerBase tower, Vector3 direction)
        {
            tower_ = tower;
            target_ = target;
            direction_ = direction;
            id_ = counter++;
            current_speed_ = stats_.FindStat(StatEnum.StartingSpeed).value_;
            is_accelerating_ = stats_.FindStat(StatEnum.StartingSpeed).value_ != stats_.FindStat(StatEnum.MaxSpeed).value_;
            if (is_accelerating_)
                acceleration_direction_ = Mathf.Sign(stats_.FindStat(StatEnum.MaxSpeed).value_ - stats_.FindStat(StatEnum.StartingSpeed).value_);
            ProjectileManager.sSingleton.AddProjectile(this);
            if(ShootStartCallback != null)
                ShootStartCallback.Invoke(this);
        }
        private void UpdateSpeed()
        {
            current_speed_ += (stats_.FindStat(StatEnum.Acceleration).value_ * delta_time_);
            if( acceleration_direction_ * (stats_.FindStat(StatEnum.MaxSpeed).value_ - current_speed_) <= 0)
            {
                current_speed_ = stats_.FindStat(StatEnum.MaxSpeed).value_;
                is_accelerating_ = false;
            }
        }
        private void UpdateTargetPosition()
        {
            if (target_ != null)
                target_pos_ = target_.position;
        }
        private void UpdateDirection()
        {
            var target_direction = (target_pos_ - transform.position).normalized;
            var rotation_value = (stats_.FindStat(StatEnum.RotationSpeed).value_ * delta_time_) / Vector3.Angle(direction_, target_direction);
            direction_ = Vector3.Lerp(direction_, target_direction, rotation_value).normalized;
        }
        private void UpdatePosition()
        {
            var movement_value = current_speed_ * delta_time_;
            var distance_to_target = (target_pos_ - transform.position).magnitude;
            movement_value = Mathf.Min(movement_value, distance_to_target);
            transform.position += direction_ * movement_value;
            if(ShootUpdateCallback != null)
                ShootUpdateCallback.Invoke(this);
        }
        private bool HitCheck()
        {
            var distance_to_target = (target_pos_ - transform.position).magnitude;
            return distance_to_target <= stats_.FindStat(StatEnum.ReachDistance).value_;
        }
        public bool UpdateMovement(float delta_time)
        {
            delta_time_ = delta_time;
            if (is_accelerating_)
                UpdateSpeed();
            UpdateTargetPosition();
            UpdateDirection();
            UpdatePosition();
            return HitCheck();
        }

        public void OnHit()
        {
            if(HitCallback != null)
                HitCallback.Invoke(this);
            if(target_ != null)
            {
                var enemy = target_.GetComponent<EnemyBase>();
                enemy.pHealth.DoDamage(pStatComponent.FindStat(StatEnum.Damage).value_);
            }
            Release();
        }

        public void Release()
        {
            if(OnRelease != null)
                OnRelease.Invoke(this);
                Destroy(gameObject);
        }


        // DELEGATES //
        public event TowerAttackEventHandler ShootStartCallback;
        public event TowerAttackEventHandler ShootUpdateCallback;
        public event TowerAttackEventHandler HitCallback;
        public event TowerAttackEventHandler OnRelease;

    }
}
