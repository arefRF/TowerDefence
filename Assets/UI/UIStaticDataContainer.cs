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

    private void Awake()
    {
        sSingleton = this;
    }

    public Color GetColor(ColorEnum color)
    {
        switch (color)
        {
            case ColorEnum.NormalFrame: return normal_frame_color_;
            case ColorEnum.HighlightFrame: return highlight_frame_color_;
            case ColorEnum.SelectIcon: return select_color_;
            case ColorEnum.NormalIcon: return normal_icon_color_;
            default: return Color.white;
        }
    }

    [SerializeField]
    private Color normal_frame_color_;
    [SerializeField]
    private Color highlight_frame_color_;
    [SerializeField]
    private Color select_color_;
    [SerializeField]
    private Color normal_icon_color_;
}
