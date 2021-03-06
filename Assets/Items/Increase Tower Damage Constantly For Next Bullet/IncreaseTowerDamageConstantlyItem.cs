using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class IncreaseTowerDamageConstantlyItem : ItemBase
{
    private float last_shoot_time_;
    private float interval_;
    private float damage_;

    public override void AddToTower(TowerBase tower)
    {
        base.AddToTower(tower);
        last_shoot_time_ = Time.timeWithCeaseFire;
        interval_ = pItemData.FindStat(StatEnum.Interval).value_;
        damage_ = pItemData.FindStat(StatEnum.Damage).value_;
        tower_.ShootStartCallback += IncreaseDamage;
    }

    public override void UnSetDataOnTower()
    {
        base.UnSetDataOnTower();
        tower_.ShootStartCallback -= IncreaseDamage;
    }
    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
    }

    // CALLBACKS //

    public void IncreaseDamage(ProjectileBase projectile)
    {
        int interval_count = (int)((Time.timeWithCeaseFire - last_shoot_time_) / interval_);
        projectile.pStatComponent.MultiplyStat(StatEnum.Damage, damage_ * interval_count);
        last_shoot_time_ = Time.timeWithCeaseFire;
    }
}
