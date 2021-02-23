using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class SangeAndYashar : ItemBase
{
    public override void Initialize(TowerBase tower, ItemData item_data)
    {
        base.Initialize(tower, item_data);
        SetDataOnTower();
    }

    public override void OnRelease()
    {
        base.OnRelease();
        UnSetDataOnTower();
        UnRegisterProjectileCallBacks();
        Destroy(gameObject);
    }

    public override void SetDataOnTower()
    {
        tower_.ShootStartCallback += RegisterProjectileCallBacks;
        tower_.pStatComponent.MultiplyStat(StatEnum.AttackTime, 1/2f);
    }

    public override void UnSetDataOnTower()
    {
        tower_.pStatComponent.MultiplyStat(StatEnum.AttackTime, 2f);
    }

    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        //projectile.ShootUpdateCallback += DecreaseSpeed;
    }

    public override void UnRegisterProjectileCallBacks()
    {
        tower_.ShootStartCallback -= RegisterProjectileCallBacks;
    }


    // CALLBACKS //
    public void DecreaseSpeed(ProjectileBase projectile)
    {
        projectile.pStats.MultiplyStat(StatEnum.Damage, 0.9f);
    }
}
