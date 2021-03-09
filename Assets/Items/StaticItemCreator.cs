using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticItemCreator : MonoBehaviour
{
    [SerializeField]
    private bool add_all_on_start_;
    public static StaticItemCreator sSinglton { get; private set; }

    private void Awake()
    {
        sSinglton = this;
        AddAllItemsOnStart();
    }
    private void AddAllItemsOnStart()
    {
        if (add_all_on_start_)
        {
            foreach (ItemData data in StaticItemsData.sSingleton.items_data_list_)
            {
                var item = CreateItem(data);
                PlayerInventory.sSingleton.AddItemToFreeSlot(item);
            }
        }
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
        GameObject item_gameobject = new GameObject();
        item_gameobject.name = item_data.item_enum_.ToString();
        ItemBase item = null;
        switch (item_data.item_enum_)
        {
            case ItemEnum.SangeAndYashar: item = item_gameobject.AddComponent<SangeAndYashar>(); break;
            case ItemEnum.IncreaseBulletDamage: item = item_gameobject.AddComponent<IncreaseBulletDamageItem>(); break;
            case ItemEnum.CreateMoreBulletsAtEnd: item = item_gameobject.AddComponent<CreateMoreBulletsAtEndItem>(); break;
            case ItemEnum.IncreaseTowerDamageConstantlyForNextBullet: item = item_gameobject.AddComponent<IncreaseTowerDamageConstantlyItem>(); break;
        }
        item.SetData(item_data);
        return item;
    }
}
