using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class TowerShootsWhenLastBulletHitsItem : ItemBase
{

    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
        projectile.ShootStartCallback += OnShootStart;
        projectile.HitCallback += OnHit;
    }

    // CALLBACKS //
    private void OnShootStart(ProjectileBase projectile)
    {
        tower_.pAttackComponent.DisableAttack();
    }

    private void OnHit(ProjectileBase projectile) 
    {
        tower_.pAttackComponent.ForceReload();
    }
}
