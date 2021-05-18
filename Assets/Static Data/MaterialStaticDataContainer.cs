using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStaticDataContainer : MonoBehaviour
{
    private static MaterialStaticDataContainer sPrivateSingleton;
    private static MaterialStaticDataContainer sEditorPrivateSingleton;
    public static MaterialStaticDataContainer sSingleton
    {
        get
        {
            if (Application.isPlaying)
                return sPrivateSingleton;
            else
            {
                if(sEditorPrivateSingleton == null)
                {
                    sEditorPrivateSingleton = FindObjectOfType<MaterialStaticDataContainer>();
                }
                return sEditorPrivateSingleton;
            }
        }
    }
    [SerializeField]
    private TowerMatSet[] tower_mat_sets_;
    private List<TowerMatSet> available_tower_colors_;

    [SerializeField]
    private List<TileMatSet> tile_materials_;
    public List<TileMatSet> pTileMaterials { get { return tile_materials_; } }

    [SerializeField]
    private bool bl;

    private void Awake()
    {
        sPrivateSingleton = this;
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
    public Color light_color_;
}

public enum TowerColor { Blue, Red, Yellow, Green, Purple, Orange }

[System.Serializable]
public class TileMatSet 
{
    public Material material_;
    public TileType type_;
}

