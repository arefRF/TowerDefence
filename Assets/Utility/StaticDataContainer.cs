using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDataContainer : MonoBehaviour
{
    public static StaticDataContainer sSingleton;

    private void Start()
    {
        sSingleton = this;
    }

    [SerializeField]
    private GameObject projectile_prefab_;
    public GameObject pProjectilePrefab { get { return projectile_prefab_;} }
}
