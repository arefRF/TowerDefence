using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class IncreaseBulletDamageItem : ItemBase
{
    private Dictionary<int, int> timer_id_dic;

    public override void AddToTower(TowerBase tower)
    {
        base.AddToTower(tower);
        timer_id_dic = new Dictionary<int, int>();
    }
    public override void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        base.RegisterProjectileCallBacks(projectile);
        projectile.ShootStartCallback += SetCallBackTimer;
        projectile.OnRelease += OnProjectileRelease;
    }

    // CALLBACKS //

    private void SetCallBackTimer(ProjectileBase projectile)
    {
        int timer_id;
        var interval = pItemData.FindStat(StatEnum.Interval);
        Timer.RegisterTimer(IncreaseDamage, interval.value_, -1, projectile, out timer_id);
        timer_id_dic.Add(projectile.pId, timer_id);
    }
    public void IncreaseDamage(ProjectileBase projectile)
    {
        var stat = pItemData.FindStat(StatEnum.Damage);
        projectile.pStatComponent.MultiplyStat(StatEnum.Damage, stat.value_);
    }

    public void OnProjectileRelease(ProjectileBase projectile)
    {
        int timer_id;
        if(timer_id_dic.TryGetValue(projectile.pId, out timer_id))
        {
            Timer.UnregisterTimer(timer_id);
        }
        else
            Debug.LogError("timer id not found. projectile id: " + projectile.pId);
    }
}
