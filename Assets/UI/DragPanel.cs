using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour
{
    [SerializeField]
    private RectTransform rect_;
    private Vector2 start_pos_;

    private void Awake()
    {
        enabled = false;
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
        EventTrigger.Entry entry_press = new EventTrigger.Entry();
        entry_press.eventID = EventTriggerType.PointerDown;
        entry_press.callback.AddListener((data) => { OnPressDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry_press);
    }
    private void OnPressDelegate(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
            start_pos_ = rect_.position;
    }
    private void OnDragDelegate(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Left)
            rect_.position = start_pos_ + (data.position - data.pressPosition);
    }
}
