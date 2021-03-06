using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerVisuals : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer[] rederers_;
    [SerializeField]
    private Light light_;
    public TowerColor pColor { get; private set; }
    public TowerBase pTower { get; set; }
    private void Awake()
    {
        //rederers_ = GetComponentsInChildren<MeshRenderer>();
        SetMaterial();
    }
    public void SetMaterial()
    {
        var set = MaterialStaticDataContainer.sSingleton.GetRandomTowerColor();
        pColor = set.color_;
        light_.color = set.light_color_;
        var mat_count = set.materials_.Length -1;
        for(int i = 0; i < rederers_.Length; i++)
        {
            var mat = set.materials_[Mathf.Min(i, mat_count)];
            rederers_[i].material = mat;
        }
    }
}
