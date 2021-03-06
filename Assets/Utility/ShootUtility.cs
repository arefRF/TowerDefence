using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class ShootUtility
{
    public static void Shoot(Transform target, TowerBase tower, Transform shoot_source)
    {
        var direction = target.position - shoot_source.position;
        direction.y = 1;
        direction = direction.normalized;
        var projectile = GameObject.Instantiate(StaticDataContainer.sSingleton.pProjectilePrefab, shoot_source.position, Quaternion.identity).GetComponent<ProjectileBase>();
        tower.InvokeShootStartEvent(projectile);
        projectile.Shoot(target, tower, direction);
    }
}
