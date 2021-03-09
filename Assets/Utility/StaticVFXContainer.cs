using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVFXContainer : MonoBehaviour
{
    public static StaticVFXContainer sSingleton;

    private void Start()
    {
        sSingleton = this;
    }

    [SerializeField]
    private GameObject enemy_hit_vfx_;
    public GameObject pEnemyHitVFX { get { return enemy_hit_vfx_; } }
}
