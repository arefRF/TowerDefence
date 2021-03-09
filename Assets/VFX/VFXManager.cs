using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager sSingleton;
    void Start()
    {
        sSingleton = this;
    }

    public void InstantiateAndPlayVFX(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        var obj = Instantiate(prefab, position, rotation);
    }
}
