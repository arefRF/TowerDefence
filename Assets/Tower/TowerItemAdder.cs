using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerItemAdder : MonoBehaviour
{
    public bool add_item_;
    public ItemEnum item_enum_;

    private TowerInventory tower_inventory_;
    void Start()
    {
        tower_inventory_ = GetComponent<TowerInventory>();
    }

    void OnValidate()    
    {
        if(Application.isPlaying)
        {
            if(add_item_)
            {
                add_item_ = false;
                tower_inventory_.AddItemToFreeSlot(item_enum_);
            }
        }
    }
}
