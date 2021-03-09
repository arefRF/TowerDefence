using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StaticItemsData : MonoBehaviour
{
    public static StaticItemsData sSingleton;

    public List<ItemData> items_data_list_;
    void Awake()
    {
        sSingleton = this;
    }

    public ItemData GetItemData(ItemEnum item_enum)
    {
        for (int i = 0; i < items_data_list_.Count; i++)
        {
            var data = items_data_list_[i];
            if (data.item_enum_ == item_enum)
                return data;
        }
        Debug.LogError("No Data Found for " + item_enum);
        return null;
    }
}
