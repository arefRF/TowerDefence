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
        last_shoot_time_ = Time.time;
        interval_ = pItemData.FindStat(StatEnum.Interval).value_;
        damage_ = pItemData.FindStat(StatEnum.Damage).value_;
    }
    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
        tower_.ShootStartCallback += IncreaseDamage;
    }

    // CALLBACKS //

    public void IncreaseDamage(ProjectileBase projectile)
    {
        int interval_count = (int)((Time.time - last_shoot_time_) / interval_);
        projectile.pStatComponent.MultiplyStat(StatEnum.Damage, damage_ * interval_count);
    }
}
