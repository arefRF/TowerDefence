using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInventory : MonoBehaviour
{
    [SerializeField]
    private int inventory_capacity_;
    [SerializeField]
    private Transform item_parent_;
    [SerializeField]
    private GameObject item_base_object_;

    private TowerBase tower_;
    private ItemBase[] items_list_;
    private int current_items_count;

    public void Start()
    {
        tower_ = GetComponent<TowerBase>();
        items_list_ = new ItemBase[inventory_capacity_];
        current_items_count = 0;
    }
    public void AddItem(ItemEnum item_enum, int index)
    {
        if (items_list_[index] != null)
        {
            Debug.LogError("slot: %index% is full. cant add item");
            return;
        }
        var item = GameObject.Instantiate(item_base_object_, Vector3.zero, Quaternion.identity);
        ItemBase component = null;
        item.transform.SetParent(item_parent_);
        item.gameObject.name = item_enum.ToString();
        switch (item_enum)
        {
            case ItemEnum.SangeAndYashar: component = item.AddComponent<SangeAndYashar>(); break;
            case ItemEnum.IncreaseBulletDamage: component = item.AddComponent<IncreaseBulletDamageItem>(); break;
            case ItemEnum.CreateMoreBulletsAtEnd: component = item.AddComponent<CreateMoreBulletsAtEndItem>(); break;
            case ItemEnum.IncreaseTowerDamageConstantlyForNextBullet: component = item.AddComponent<IncreaseTowerDamageConstantlyItem>(); break;
        }
        ItemData item_data = null;
        for (int i = 0; i < StaticItemsData.sSingleton.items_data_list_.Count; i++)
        {
            if (StaticItemsData.sSingleton.items_data_list_[i].item_enum_ == item_enum)
            {
                item_data = StaticItemsData.sSingleton.items_data_list_[i];
                break;
            }
        }
        current_items_count++;
        component.Initialize(tower_, item_data);
    }

    public void AddItemToFreeSlot(ItemEnum item_enum)
    {
        int free_index;
        if (TryGetNetFreeSlot(out free_index))
            AddItem(item_enum, free_index);
        else
            Debug.LogError("slot: " + free_index + "is full. cant add item");
    }

    private bool TryGetNetFreeSlot(out int index)
    {
        index = -1;
        for (int i = 0; i < items_list_.Length; i++)
        {
            if (items_list_[i] == null)
            {
                index = i;
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(ItemEnum item_enum)
    {
        for (int i = 0; i < items_list_.Length; i++)
        {
            var item = items_list_[i];
            if (item.item_data_.item_enum_ == item_enum)
            {
                items_list_[i] = null;
                item.OnRelease();
                current_items_count--;
                return;
            }
        }
        Debug.LogError("item not found for removing. Item: " + item_enum);
    }

    public void RemoveItemAt(int index)
    {
        if (items_list_[index] == null)
        {
            Debug.LogError("no item is in slot: " + index);
            return;
        }
        var item = items_list_[index];
        item.OnRelease();
        items_list_[index] = null;
        current_items_count--;
    }
}
