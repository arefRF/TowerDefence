using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInventory : MonoBehaviour
{
    [SerializeField]
    private int inventory_capacity_;
    [SerializeField]
    private Transform item_parent_;

    private TowerBase tower_;
    private ItemBase[] items_list_;
    private int current_items_count;

    public void Start()
    {
        tower_ = GetComponent<TowerBase>();
        items_list_ = new ItemBase[inventory_capacity_];
        current_items_count = 0;
    }

    public void AddItem(ItemBase item, int index)
    {
        if (items_list_[index] != null)
        {
            Debug.LogError("slot: %index% is full. cant add item");
            return;
        }
        item.transform.SetParent(item_parent_);
        item.Initialize(tower_);
        items_list_[index] = item;
        current_items_count++;
    }

    public void AddItemToFreeSlot(ItemBase item)
    {
        int free_index;
        if (TryGetNetFreeSlot(out free_index))
            AddItem(item, free_index);
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
