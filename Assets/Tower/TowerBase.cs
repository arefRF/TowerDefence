using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class TowerBase : MonoBehaviour
{
    private TowerAttackComponent attack_component_;
    public TowerAttackComponent pAttackComponent { get { return attack_component_; } }
    private TowerSenseComponent sense_component_;
    public TowerSenseComponent pSenseComponent { get { return sense_component_; } }
    private TowerStatComponent stat_component_;
    public TowerStatComponent pStatComponent { get { return stat_component_; } }
    private RangeWeapon weapon_;
    public RangeWeapon pWeapon { get { return weapon_; } }

    public void Start()
    {
        InitializeOnStart();
    }

    public void InitializeOnStart()
    {
        attack_component_ = GetComponent<TowerAttackComponent>();
        sense_component_ = GetComponent<TowerSenseComponent>();
        stat_component_ = GetComponent<TowerStatComponent>();    
        weapon_ = GetComponent<RangeWeapon>();
    }
    
    public event TowerAttackEventHandler ShootStartCallback;

    public void InvokeShootStartEvent(ProjectileBase projectile)
    {
        if(ShootStartCallback != null)
            ShootStartCallback.Invoke(projectile);
    }
}

public delegate void TowerAttackEventHandler(ProjectileBase projectile);
