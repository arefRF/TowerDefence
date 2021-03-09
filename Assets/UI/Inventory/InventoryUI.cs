using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private ItemSlotUI[] slots_;

    public InventoryBase pInventory { get; private set; }

    public void SetupInventory(InventoryBase inventory)
    {
        if (pInventory != null)
            pInventory.OnSlotChanged -= OnSlotChanged;

        pInventory = inventory;
        SetupSlots();
        pInventory.OnSlotChanged += OnSlotChanged;
    }

    private void SetupSlots()
    {
        for(int i = 0; i < slots_.Length; i++)
        {
            slots_[i].Setup(pInventory, i);
        }
    }

    private void OnSlotChanged(int index)
    {
        slots_[index].BuildSlot();
    }
}
