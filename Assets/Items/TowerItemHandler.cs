using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerItemHandler : MonoBehaviour
{
    [SerializeField]
    private Transform item_parent_;
    [SerializeField]
    private GameObject item_base_object_;

    private TowerBase tower;
    private List<ItemBase> items_list_;

    public void Start()
    {
        tower = GetComponent<TowerBase>();
        items_list_ = new List<ItemBase>();
    }
    public void AddItem(ItemEnum item_enum)
    {
        var item = GameObject.Instantiate(item_base_object_, Vector3.zero, Quaternion.identity);
        ItemBase component = null;
        item.transform.SetParent(item_parent_);
        item.gameObject.name = item_enum.ToString();
        switch(item_enum)
        {
            case ItemEnum.SangeAndYashar : component = item.AddComponent<SangeAndYashar>(); items_list_.Add(component); break;
        }
        ItemData item_data = null;
        for(int i=0; i<StaticItemsData.sSingleton.items_data_list_.Count; i++)
        {
            if(StaticItemsData.sSingleton.items_data_list_[i].item_enum_ == item_enum)
            {
                item_data = StaticItemsData.sSingleton.items_data_list_[i];
                break;
            }
        }
        Debug.LogError(item_data);
        component.Initialize(tower, item_data);
    }

    public void RemoveItem(ItemEnum item_enum)
    {
        for(int i=0; i<items_list_.Count; i++)
        {
            var item = items_list_[i];
            if(item.item_data_.item_enum_ == item_enum)
            {
                items_list_.RemoveAt(i);
                item.OnRelease();
                return;
            }
        }
        Debug.LogError("item not found for removing. Item: " + item_enum);
    }
}
