using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class ItemBase : MonoBehaviour
{
    protected TowerBase tower_;

    public ItemData pItemData { get; private set; }
    public InventoryBase pInvetory { get; private set; }
    public int pInventoryIndex { get; private set; }

    /// <summary>
    /// call Base first
    /// </summary>
    /// 
    public void SetInvetoryData(InventoryBase inventory, int index)
    {
        pInvetory = inventory;
        pInventoryIndex = index;
    }
    public void RemoveFromInventory()
    {
        if (pInvetory != null)
            pInvetory.RemoveItem(pInventoryIndex);
        pInvetory = null;
    }
    public void SetData(ItemData item_data)
    {
        pItemData = item_data;
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
        pItemData = null;
        UnSetDataOnTower();
        Destroy(gameObject);
    }
    public virtual void SetDataOnTower() { }
    public virtual void UnSetDataOnTower() { }
    public virtual void RegisterProjectileCallBacks(ProjectileBase projectile)
    {
        Debug.Log("implement visual moddifier here");
    }
}
