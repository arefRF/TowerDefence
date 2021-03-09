using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class ExplodeWhenHitItem : ItemBase
{
    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
        projectile.HitCallback += Explode;
    }

    // CALLBACKS //

    private void Explode(ProjectileBase projectile)
    {
        var radius = pItemData.FindStat(StatEnum.Radius).value_;
        var damage = pItemData.FindStat(StatEnum.DamageMultiplier).value_ * projectile.pStatComponent.FindStat(StatEnum.Damage).value_;
        ShootUtility.CreateExplosion(projectile.transform.position, projectile.transform.rotation, radius, damage);
    }
}
