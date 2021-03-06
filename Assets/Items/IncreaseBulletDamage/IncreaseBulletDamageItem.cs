using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class IncreaseBulletDamageItem : ItemBase
{
    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
        projectile.ShootUpdateCallback += IncreaseDamage;
    }

    // CALLBACKS //
    public void IncreaseDamage(ProjectileBase projectile)
    {
        var stat = item_data_.FindStat(StatEnum.AttackTime);
        tower_.pStatComponent.MultiplyStat(StatEnum.AttackTime, stat.value_);
    }
}
