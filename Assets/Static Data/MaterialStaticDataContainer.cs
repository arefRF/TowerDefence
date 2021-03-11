using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStaticDataContainer : MonoBehaviour
{
    public static MaterialStaticDataContainer sSingleton { get; private set; }
    [SerializeField]
    private TowerMatSet[] tower_mat_sets_;
    private List<TowerMatSet> available_tower_colors_;

    private void Awake()
    {
        sSingleton = this;
        available_tower_colors_ = new List<TowerMatSet>(tower_mat_sets_.Length);
        foreach(TowerMatSet set in tower_mat_sets_)
        {
            available_tower_colors_.Add(set);
        }
    }

    public TowerMatSet GetRandomTowerColor()
    {
        var random = Random.Range(0, available_tower_colors_.Count);
        var set = available_tower_colors_[random];
        available_tower_colors_.RemoveAt(random);
        return set;
    }
}

[System.Serializable]
public class TowerMatSet
{
    public TowerColor color_;
    public Material[] materials_;
}

public enum TowerColor { Blue, Red, Yellow, Green, Purple, Orange }

