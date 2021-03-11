using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private Image frame_, icon_;
    private int index_;
    private bool is_selected_;
    private void Awake()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();

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

        if (!is_selected_)
            frame_.color = UIStaticDataContainer.sSingleton.GetColor(ColorEnum.NormalFrame);
    }
    private void OnPressDelegate(PointerEventData data)
    {
        Select();
    }
    private void OnHighlightDelegate(PointerEventData data)
    {
        if (!is_selected_)
        {
            frame_.color = UIStaticDataContainer.sSingleton.GetColor(ColorEnum.HighlightFrame);
            if (UIManager.sSingleton.pMode == UIManager.UIMode.Drag)
                Select();
        }
    }
    private void OnDehighlightDelegate(PointerEventData data)
    {
        if (!is_selected_)
            frame_.color = UIStaticDataContainer.sSingleton.GetColor(ColorEnum.NormalFrame);
    }

    private void Select()
    {
        UIManager.sSingleton.SelectTower(index_);
    }

    public void SetSelected(bool active)
    {
        is_selected_ = active;
        frame_.color = active ? UIStaticDataContainer.sSingleton.GetColor(ColorEnum.SelectIcon) : UIStaticDataContainer.sSingleton.GetColor(ColorEnum.NormalFrame);
    }
    public void SetIndex(int index)
    {
        index_ = index;
        icon_.color = UIStaticDataContainer.sSingleton.GetTowerColor(TowerManager.sSingleton.pTowers[index_].pVisuals.pColor);
    }
}
