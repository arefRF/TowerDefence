using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class ShootUtility
{
    public static void Shoot(Transform target, TowerBase tower, Transform shoot_source, int order, float damage)
    {
        var direction = target.position - shoot_source.position;
        direction.y = 1;
        direction = direction.normalized;
        var projectile = GameObject.Instantiate(tower.pProjectile, shoot_source.position, Quaternion.identity).GetComponent<ProjectileBase>();
        tower.InvokeShootStartEvent(projectile);
        var stat = projectile.GetComponent<StatComponent>();
        stat.FindStat(StatEnum.Damage).value_ = damage;
        projectile.Shoot(target, tower, direction, order);
    }

    public static void CreateExplosion(Vector3 position, Quaternion rotation, float radius, float damage)
    {
        var explosion = GameObject.Instantiate(StaticDataContainer.sSingleton.pExplosionPrefab, position, rotation).GetComponent<ExplosiveComponent>();
        explosion.Explode(radius, damage);

    }
}
