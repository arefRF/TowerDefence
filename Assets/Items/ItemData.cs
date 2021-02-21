using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData", order = 2)]
public class ItemData : ScriptableObject
{
    public ItemEnums item_enum;

    public List<StatBase> stats_;
}
