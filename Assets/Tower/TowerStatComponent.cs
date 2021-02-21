using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatComponent : MonoBehaviour
{
    [SerializeField] private float damage_;
    public float pDamage { get { return damage_; } }
    [SerializeField] private float attack_time_;
    public float pAttackTime { get { return attack_time_; } }
    [SerializeField] private float projectile_speed_;
    public float pProjectileSpeed { get { return projectile_speed_; } }


    [SerializeField]
    private float time_to_next_attack_;
    public float pTimeToNextAttack { get{ return time_to_next_attack_; } set { time_to_next_attack_ = value; } }
}
