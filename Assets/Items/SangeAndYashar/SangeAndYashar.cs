using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class SangeAndYashar : ItemBase
{
    public override void SetDataOnTower()
    {
        tower_.pStatComponent.MultiplyStat(StatEnum.AttackTime, 1/2f);
    }

    public override void UnSetDataOnTower()
    {
        tower_.pStatComponent.MultiplyStat(StatEnum.AttackTime, 2f);
    }

    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
        projectile.ShootUpdateCallback += DecreaseSpeed;
    }
    
    // CALLBACKS //
    public void DecreaseSpeed(ProjectileBase projectile)
    {
        projectile.pStats.MultiplyStat(StatEnum.Damage, 0.9f);
    }
}
