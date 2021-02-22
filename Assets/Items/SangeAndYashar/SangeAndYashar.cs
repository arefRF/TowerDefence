using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SangeAndYashar : ItemBase
{
    public override void Initialize(TowerBase tower, ItemData item_data)
    {
        base.Initialize(tower, item_data);
    }

    public override void OnRelease()
    {
        base.OnRelease();
        Destroy(gameObject);
    }

    public override void SetDataOnTower()
    {

    }

    public override void UnSetDataOnTower()
    {

    }

    public override void RegisterCallBacks()
    {
        
    }

    public override void UnRegisterCallBacks()
    {
        
    }
}
