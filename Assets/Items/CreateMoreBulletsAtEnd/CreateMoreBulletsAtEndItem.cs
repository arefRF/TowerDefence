using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class CreateMoreBulletsAtEndItem : ItemBase
{
    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
        projectile.HitCallback += CreateAditionalBullets;
    }

    // CALLBACKS //

    private void CreateAditionalBullets(ProjectileBase projectile)
    {
        if(projectile.pOrder >= item_data_.supported_order_)
            return;
        var count = item_data_.FindStat(StatEnum.Count).value_;
        for(int i=0; i < count; i++)
        {
            var target = EnemyManager.sSingletone.GetRandomEnemy();
            ShootUtility.Shoot(target.transform, tower_, projectile.transform, projectile.pOrder + 1);
        }
    }
}
