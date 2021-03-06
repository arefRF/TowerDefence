using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/Item Data", order = 2)]
public class ItemData : ScriptableObject
{
    public ItemEnum item_enum_;
    [PreviewSprite]
    public Sprite icon_;
    [TextArea(1, 10)]
    public string name_;
    [TextArea(3, 10)]
    public string description_;
    public int supported_order_;
    public List<BulletVisualModifierEnum> visual_modifier_list_;
    public List<StatBase> stats_;

    public StatBase FindStat(StatEnum stat_enum)
    {
        for (int i = 0; i < stats_.Count; i++)
        {
            if (stats_[i].stat_enum_ == stat_enum)
                return stats_[i];
        }
        Debug.LogError("stat not found. Stat: " + stat_enum);
        return null;
    }

}
