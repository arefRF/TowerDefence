using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInventory : InventoryBase
{
    public TowerBase pTower { get; private set; }
    public void SetTower(TowerBase tower)
    {
        pTower = tower;
    }
    protected override void FinalizeAddingItem(ItemBase item)
    {
        item.Initialize(pTower);
    }
    protected override void FinalizeRemovingItem(ItemBase item)
    {
        item.OnRelease();
    }
}
