using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class ItemBase : MonoBehaviour
{
    protected TowerBase tower_;

    public ItemData item_data_;

    /// <summary>
    /// call Base first
    /// </summary>
    /// 
    public void SetData(ItemData item_data)
    {
        item_data_ = item_data;
    }
    public virtual void Initialize(TowerBase tower) 
    {
        tower_ = tower;
        tower_.ShootStartCallback += RegisterProjectileCallBacks;
        SetDataOnTower();
    }

    /// <summary>
    /// call Base first
    /// </summary>
    public virtual void OnRelease()
    {
        tower_ = null;
        item_data_ = null;
        UnSetDataOnTower();
        Destroy(gameObject);
    }
    public virtual void SetDataOnTower() {}
    public virtual void UnSetDataOnTower() {}
    public virtual void RegisterProjectileCallBacks(ProjectileBase projectile) 
    {
        Debug.Log("implement visual moddifier here");
    }
}
