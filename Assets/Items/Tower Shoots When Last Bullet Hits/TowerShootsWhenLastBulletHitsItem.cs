using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class TowerShootsWhenLastBulletHitsItem : ItemBase
{
    public override void SetDataOnTower()
    {
        base.SetDataOnTower();
        tower_.PreShootStartCallback += ShootAdditionalBullets;
    }

    public override void UnSetDataOnTower()
    {
        base.UnSetDataOnTower();
        tower_.PreShootStartCallback -= ShootAdditionalBullets;
    }

    // CALLBACKS //
    private void ShootAdditionalBullets()
    {
        var count = pItemData.FindStat(StatEnum.Count).value_;
        var damage = tower_.pStatComponent.FindStat(StatEnum.Damage).value_;
        for(int i = 0; i < count; i++)
        {
            var target = EnemyManager.sSingletone.GetRandomEnemy();
            ShootUtility.Shoot(target.transform, tower_, tower_.transform, 0, damage);
        }
    }
}
