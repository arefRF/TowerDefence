using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/Item Data", order = 2)]
public class ItemData : ScriptableObject
{
    public ItemEnum item_enum_;

    public List<StatBase> stats_;
}
