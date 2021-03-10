using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager sSingleton { get; private set; }

    public enum UIMode { Standard, Drag, TileSelect }
    public UIMode pMode { get; private set; }

    public ItemSlotUI pCurrentSlot { get; private set; }
    public ItemSlotUI pActiveSlot { get; set; }
    [SerializeField]
    private RectTransform canvas_rect_;
    [SerializeField]
    private Image drag_image_;
    [SerializeField]
    private InventoryUI player_inventory_ui_;
    [SerializeField]
    private InventoryUI tower_inventory_ui_;
    [SerializeField]
    private TowerButton[] tower_buttons_;
    [SerializeField]
    private DescriptionPanel description_panel_;

    public int pCurrentTowerIndex { get; private set; }

    private void Awake()
    {
        sSingleton = this;
        drag_image_.enabled = false;
    }
    private void Start()
    {
        player_inventory_ui_.SetupInventory(PlayerInventory.sSingleton);
        SetIndexTowerButtons();
        SelectTower(0);
    }
    private void SetIndexTowerButtons()
    {
        for (int i = 0; i < tower_buttons_.Length; i++)
        {
            tower_buttons_[i].SetIndex(i);
        }
    }
    public void ActiveDragMode(ItemSlotUI slot)
    {
        pMode = UIMode.Drag;
        drag_image_.sprite = slot.pItem.pItemData.icon_;
        drag_image_.enabled = true;
        pCurrentSlot = slot;
    }
    public void DeactiveDragMode()
    {
        pMode = UIMode.Standard;
        drag_image_.enabled = false;
        pCurrentSlot = null;
    }
    private void Update()
    {
        switch (pMode)
        {
            case UIMode.Drag: UpdateDrag(); return;
        }
    }
    private void UpdateDrag()
    {
        drag_image_.rectTransform.position = Input.mousePosition;
    }
    public void PointerUp()
    {
        if (pMode == UIMode.Drag)
        {
            if (pActiveSlot != null)
            {
                pActiveSlot.AddItemToSlot(pCurrentSlot.pItem);
            }
            else
            {
                pCurrentSlot.StopDraging();
            }
            DeactiveDragMode();
        }
    }
    public void SelectTower(int index)
    {
        tower_buttons_[pCurrentTowerIndex].SetSelected(false);
        pCurrentTowerIndex = index;
        tower_buttons_[pCurrentTowerIndex].SetSelected(true);
        tower_inventory_ui_.SetupInventory(TowerManager.sSingleton.pTowers[pCurrentTowerIndex].pInventory);
    }

    public float GetCanvasScale()
    {
        return canvas_rect_.localScale.x;
    }

    public void ShowPanel(string title, string description)
    {
        if (pMode == UIMode.Standard)
            description_panel_.ShowPanel(title, description);
    }

    public void HidePanel()
    {
        description_panel_.HidePanel();
    }
}
