using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField]
    private Image frame_, icon_;

    public enum SlotMode {Empty,Full,Draged}
    public SlotMode pMode { get; private set; }
    public ItemBase pItem { get; private set; }
    public InventoryBase pInventory { get; private set; }
    public int pIndex { get; private set; }

    private void Awake()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();

        EventTrigger.Entry entry_drag = new EventTrigger.Entry();
        entry_drag.eventID = EventTriggerType.Drag;
        entry_drag.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry_drag);

        EventTrigger.Entry entry_press = new EventTrigger.Entry();
        entry_press.eventID = EventTriggerType.PointerDown;
        entry_press.callback.AddListener((data) => { OnPressDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry_press);

        EventTrigger.Entry entry_highlight = new EventTrigger.Entry();
        entry_highlight.eventID = EventTriggerType.PointerEnter;
        entry_highlight.callback.AddListener((data) => { OnHighlightDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry_highlight);

        EventTrigger.Entry entry_dehighlight = new EventTrigger.Entry();
        entry_dehighlight.eventID = EventTriggerType.PointerExit;
        entry_dehighlight.callback.AddListener((data) => { OnDehighlightDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry_dehighlight);

        frame_.color = UIStaticDataContainer.sSingleton.GetColor(ColorEnum.NormalFrame);
    }
    private void OnPressDelegate(PointerEventData data)
    {
    }
    private void OnHighlightDelegate(PointerEventData data)
    {
        frame_.color = UIStaticDataContainer.sSingleton.GetColor(ColorEnum.HighlightFrame);
        UIManager.sSingleton.pActiveSlot = this;
    }
    private void OnDehighlightDelegate(PointerEventData data)
    {
        frame_.color = UIStaticDataContainer.sSingleton.GetColor(ColorEnum.NormalFrame);
        UIManager.sSingleton.pActiveSlot = null;
    }
    private void OnDragDelegate(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left && pMode == SlotMode.Full)
        {
            StartDraging();
        }
    }
    private void StartDraging()
    {
        icon_.enabled = false;
        pMode = SlotMode.Draged;
        UIManager.sSingleton.ActiveDragMode(this);
    }
    public void StopDraging()
    {
        icon_.enabled = true;
        pMode = SlotMode.Full;
    }
    public void Setup(InventoryBase inventory,int index)
    {
        pInventory = inventory;
        pIndex = index;
        BuildSlot();
    }

    public void BuildSlot()
    {
        pItem = pInventory.pItems[pIndex];
        if (pItem != null)
        {
            pMode = SlotMode.Full;
            icon_.sprite = pItem.pItemData.icon_;
            icon_.enabled = true;
        }
        else
        {
            pMode = SlotMode.Empty;
            icon_.enabled = false;
        }
    }

    public void AddItemToSlot(ItemBase item)
    {
        pInventory.EvaluateAddingItem(item, pIndex);
    }
}
