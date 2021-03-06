using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class SangeAndYashar : ItemBase
{
    public override void SetDataOnTower()
    {
        var stat = item_data_.FindStat(StatEnum.AttackTime);
        tower_.pStatComponent.MultiplyStat(StatEnum.AttackTime, stat.value_);
    }

    public override void UnSetDataOnTower()
    {
        var stat = item_data_.FindStat(StatEnum.AttackTime);
        tower_.pStatComponent.MultiplyStat(StatEnum.AttackTime, 1/stat.value_);
    }

    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
    }
}
