using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hive.Projectile
{
    public class ProjectileBase : MonoBehaviour
    {
        private ProjectileDataAsset data_;
        private Vector3 direction_;
        private float current_speed_;
        private Transform target_;
        private float delta_time_;
        private bool is_accelerating_;
        private float acceleration_direction_;

        public void Shoot(Transform target, ProjectileDataAsset data, Vector3 direction)
        {
            target_ = target;
            direction_ = direction;
            data_ = data;
            current_speed_ = data_.starting_speed_;
            is_accelerating_ = data_.starting_speed_ != data_.target_speed_;
            if (is_accelerating_)
                acceleration_direction_ = Mathf.Sign(data_.target_speed_ - data_.starting_speed_);
            ProjectileManager.sSingleton.AddProjectile(this);
        }
        private void UpdateSpeed()
        {
            current_speed_ += (data_.acceleration_ * delta_time_);
            if( acceleration_direction_ * (data_.target_speed_ - current_speed_) <= 0)
            {
                current_speed_ = data_.target_speed_;
                is_accelerating_ = false;
            }
        }
        private void UpdateDirection()
        {
            var target_direction = (target_.position - transform.position).normalized;
            var rotation_value = (data_.rotation_speed_ * delta_time_) / Vector3.Angle(direction_, target_direction);
            direction_ = Vector3.Lerp(direction_, target_direction, rotation_value).normalized;
        }
        private void UpdatePosition()
        {
            var movement_value = current_speed_ * delta_time_;
            var distance_to_target = (target_.position - transform.position).magnitude;
            movement_value = Mathf.Min(movement_value, distance_to_target);
            transform.position += direction_ * movement_value;
        }
        private bool HitCheck()
        {
            var distance_to_target = (target_.position - transform.position).magnitude;
            return distance_to_target <= data_.reach_distance_;
        }
        public bool UpdateMovement(float delta_time)
        {
            delta_time_ = delta_time;
            if (is_accelerating_)
                UpdateSpeed();
            UpdateDirection();
            UpdatePosition();
            return HitCheck();
        }

    }
}
