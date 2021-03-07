using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class RangeWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab_;
    [SerializeField]
    private Transform target_;
    [SerializeField]
    private float shoot_interval_;
    [SerializeField]
    private ProjectileDataAsset data_;
    private float last_shoot_time_;

    private TowerBase tower_;

    void Start()
    {
        tower_ = GetComponent<TowerBase>();
    }

    void Update()
    {
        //if (last_shoot_time_ + shoot_interval_ < Time.time)
            //Shoot();
    }

    public void Shoot(GameObject target)
    {
        target_ = target.transform;
        tower_.InvokePreShootStartEvent();
        ShootUtility.Shoot(target_, tower_, transform, 0);
    }
}
