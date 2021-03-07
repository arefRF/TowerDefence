using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private int slot_count_;

    private ItemData[] slots_;
    public ItemData[] pSlots => slots_;
    private static PlayerInventory singleton_;
    public static PlayerInventory sSingleton => singleton_;
    private void Awake()
    {
        singleton_ = this;
        slots_ = new ItemData[slot_count_];
    }

    public void AddItem(ItemData data, int index)
    {
        if (slots_[index] == null)
            slots_[index] = data;
    }

    public void AddItemToFreeSlot(ItemData data)
    {
        int free_index;
        if (TryGetNetFreeSlot(out free_index))
            AddItem(data, free_index);
        else
            Debug.LogError("slot: %free_index% is full. cant add item");
    }

    private bool TryGetNetFreeSlot(out int index)
    {
        index = -1;
        for (int i = 0; i < slots_.Length; i++)
        {
            if (slots_[i] == null)
            {
                index = i;
                return true;
            }
        }
        return false;
    }
    public void RemoveItemAt(int index)
    {
        slots_[index] = null;
    }
}
