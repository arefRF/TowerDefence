using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTools : MonoBehaviour
{
    public static List<TileBase> GetNeighborTiles(Vector3 position, float radius) 
    {
        var ret = new List<TileBase>();
        foreach(TileBase[] arr in Map.sSingleton.tiles_)
        {
            foreach (TileBase tile in arr) 
            {
                if (Vector3.Distance(tile.transform.position, position) < radius + Mathf.Epsilon)
                    ret.Add(tile);
            }
        }
        return ret;
    }
}
