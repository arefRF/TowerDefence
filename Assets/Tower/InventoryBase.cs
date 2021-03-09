using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBase : MonoBehaviour
{
    [SerializeField]
    private int inventory_capacity_;
    [SerializeField]
    private Transform item_parent_;

    private ItemBase[] items_;
    public ItemBase[] pItems => items_;

    public Action<int> OnSlotChanged;

    protected virtual void Awake()
    {
        items_ = new ItemBase[inventory_capacity_];
    }
    public void EvaluateAddingItem(ItemBase new_item, int index)
    {
        var old_item = items_[index];
        var new_item_old_inventory = new_item.pInvetory;
        var new_item_old_index = new_item.pInventoryIndex;
        new_item.RemoveFromInventory();
        if (old_item != null)
        {
            old_item.RemoveFromInventory();
            if (new_item_old_inventory != null)
                new_item_old_inventory.AddItem(old_item, new_item_old_index);
        }
        AddItem(new_item, index);
    }
    public void AddItem(ItemBase item, int index)
    {
        item.transform.SetParent(item_parent_);
        items_[index] = item;
        item.SetInvetoryData(this, index);
        OnSlotChanged?.Invoke(index);
        FinalizeAddingItem(item);
    }
    protected virtual void FinalizeAddingItem(ItemBase item)
    {

    }
    public void RemoveItem(ItemBase item)
    {
        for (int i = 0; i < items_.Length; i++)
        {
            if (items_[i] == item)
            {
                RemoveItem(i);
                return;
            }
        }
        Debug.LogError("item not found for removing. Item: " + item);
    }
    public void RemoveItem(int index)
    {
        var item = items_[index];
        if(item != null)
        {
            items_[index] = null;
            OnSlotChanged?.Invoke(index);
            FinalizeRemovingItem(item);
        }
    }
    protected virtual void FinalizeRemovingItem(ItemBase item)
    {

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
        for (int i = 0; i < items_.Length; i++)
        {
            if (items_[i] == null)
            {
                index = i;
                return true;
            }
        }
        return false;
    }
}
