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
    private StatComponent stat_component_;
    public StatComponent pStatComponent { get { return stat_component_; } }
    private RangeWeapon weapon_;
    public RangeWeapon pWeapon { get { return weapon_; } }
    private TowerHealthComponent health_component_;
    public TowerHealthComponent pHealthComponent { get { return health_component_; } }
    private Vector3 initial_position;
    private UITileController ui_tile_;
    public UITileController pUITile { get { return ui_tile_; } }

    public event TowerPreAttackEventHandler PreShootStartCallback;
    public event TowerAttackEventHandler ShootStartCallback;
    public TowerInventory pInventory { get; private set; }
    public TowerVisuals pVisuals { get; private set; }
    public GameObject pProjectile { get; private set; }
    public void Start()
    {
        InitializeOnStart();
    }

    public void InitializeOnStart()
    {
        attack_component_ = GetComponent<TowerAttackComponent>();
        sense_component_ = GetComponent<TowerSenseComponent>();
        stat_component_ = GetComponent<StatComponent>();
        weapon_ = GetComponent<RangeWeapon>();
        health_component_ = GetComponent<TowerHealthComponent>();
        pInventory = GetComponent<TowerInventory>();
        pVisuals = transform.parent.gameObject.GetComponentInChildren<TowerVisuals>();
        pVisuals.pTower = this;
        pInventory.SetTower(this);
        pProjectile = StaticDataContainer.sSingleton.GetProjectile(pVisuals.pColor);
        initial_position = transform.position;
        UndeployTower();
    }


    public void InvokeShootStartEvent(ProjectileBase projectile)
    {
        if (ShootStartCallback != null)
            ShootStartCallback.Invoke(projectile);
    }

    public void InvokePreShootStartEvent()
    {
        if (PreShootStartCallback != null)
            PreShootStartCallback.Invoke();
    }

    public void DeployTower(UITileController ui_tile)
    {
        gameObject.SetActive(true);
        transform.parent.position = ui_tile.transform.position;
        ui_tile_ = ui_tile;
        ui_tile_.Refresh();
    }

    public void UndeployTower()
    {
        gameObject.SetActive(false);
        transform.parent.position = initial_position;
        if (ui_tile_ != null)
        {
            ui_tile_.Refresh();
            ui_tile_ = null;
        }
    }
}

public delegate void TowerAttackEventHandler(ProjectileBase projectile);
public delegate void TowerPreAttackEventHandler();
