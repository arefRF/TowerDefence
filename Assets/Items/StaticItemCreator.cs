using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticItemCreator : MonoBehaviour
{
    private static StaticItemCreator singletone_;
    public static StaticItemCreator sSinglton => singletone_;

    private void Awake()
    {
        singletone_ = this;
    }
    public ItemBase CreateItem(ItemEnum item_enum)
    {
        var data = StaticItemsData.sSingleton.GetItemData(item_enum);
        if (data != null)
            return CreateItem(data);
        else
            return null;
    }
    public ItemBase CreateItem(ItemData item_data)
    {
        GameObject item_gameobjec = new GameObject();
        item_gameobjec.name = item_data.item_enum_.ToString();
        ItemBase item = null;
        switch (item_data.item_enum_)
        {
            case ItemEnum.SangeAndYashar: item = item_gameobjec.AddComponent<SangeAndYashar>(); break;
            case ItemEnum.IncreaseBulletDamage: item = item_gameobjec.AddComponent<IncreaseBulletDamageItem>(); break;
            case ItemEnum.CreateMoreBulletsAtEnd: item = item_gameobjec.AddComponent<CreateMoreBulletsAtEndItem>(); break;
        }
        item.SetData(item_data);
        return item;
    }
}
