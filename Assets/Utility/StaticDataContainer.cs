using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDataContainer : MonoBehaviour
{
    public static StaticDataContainer sSingleton;

    private void Awake()
    {
        sSingleton = this;
    }
    [SerializeField]
    private TowerProjectileSet[] projectiles_;
    public GameObject GetProjectile(TowerColor color)
    {
        for (int i = 0; i < projectiles_.Length; i++)
        {
            if (color == projectiles_[i].color_)
                return projectiles_[i].projectile_;
        }
        return projectiles_[0].projectile_;
    }
    [SerializeField]
    private GameObject projectile_prefab_;
    public GameObject pProjectilePrefab { get { return projectile_prefab_;} } 

    [SerializeField]
    private GameObject explosion_prefab_;
    public GameObject pExplosionPrefab { get { return explosion_prefab_; } }
    
    [SerializeField]
    private GameObject dark_aura_prefab_;
    public GameObject pDarkAuraPrefab { get { return dark_aura_prefab_; } }
}
[System.Serializable]
public class TowerProjectileSet
{
    public TowerColor color_;
    public GameObject projectile_;
}
