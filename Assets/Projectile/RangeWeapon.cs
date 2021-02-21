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

    void Update()
    {
        //if (last_shoot_time_ + shoot_interval_ < Time.time)
            //Shoot();
    }
    private void Shoot()
    {
        var direction = target_.position - transform.position;
        direction.y = 1;
        direction = direction.normalized;
        var projectile = Instantiate(prefab_, transform.position, Quaternion.identity).GetComponent<ProjectileBase>();
        projectile.Shoot(target_, data_, direction);
        last_shoot_time_ = Time.time;
    }

    public void Shoot(GameObject target)
    {
        target_ = target.transform;
        Shoot();
    }
}
