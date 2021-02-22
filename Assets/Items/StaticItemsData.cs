using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StaticItemsData : MonoBehaviour
{
    public static StaticItemsData sSingleton;

    public List<ItemData> items_data_list_;
    void Start()
    {
        sSingleton = this;
    }
}
