using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : InventoryBase
{
    private static PlayerInventory singleton_;
    public static PlayerInventory sSingleton { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        sSingleton = this;
    }
}
