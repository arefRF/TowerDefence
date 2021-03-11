using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorEnum
{
    NormalFrame = 1,
    HighlightFrame = 2,
    SelectIcon = 3,
    NormalIcon = 4,
}

public class UIStaticDataContainer : MonoBehaviour
{
    public static UIStaticDataContainer sSingleton { get; private set; }
    [SerializeField]
    private List<ColorEnumPair> colors_;
    [SerializeField]
    private List<TowerColorEnumPair> tower_colors_;

    private void Awake()
    {
        sSingleton = this;
    }

    public Color GetColor(ColorEnum color)
    {
        for(int i = 0; i < colors_.Count; i++)
        {
            if (color == colors_[i].enum_)
                return colors_[i].color_;
        }
        return Color.white;
    }
    public Color GetTowerColor(TowerColor color)
    {
        for (int i = 0; i < tower_colors_.Count; i++)
        {
            if (color == tower_colors_[i].enum_)
                return tower_colors_[i].color_;
        }
        return Color.white;
    }
}

[System.Serializable]
public class ColorEnumPair
{
    public ColorEnum enum_;
    public Color color_;
}

[System.Serializable]
public class TowerColorEnumPair
{
    public TowerColor enum_;
    public Color color_;
}
