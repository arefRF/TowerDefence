using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerItemAdder : MonoBehaviour
{
    public bool add_item_;
    public ItemEnum item_enum_;
    
    private TowerItemHandler tower_item_handler_;
    void Start()
    {
        tower_item_handler_ = GetComponent<TowerItemHandler>();
    }

    void OnValidate()    
    {
        if(Application.isPlaying)
        {
            if(add_item_)
            {
                add_item_ = false;
                tower_item_handler_.AddItem(item_enum_);
            }
        }
    }
}
