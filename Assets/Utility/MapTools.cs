using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTools : MonoBehaviour
{
    public static List<TileBase> GetNeighborTiles(TileBase tile) 
    {
        var ret = new List<TileBase>();
        TileBase temp;
        if((temp = GetNeightborTile(tile, Direction.Down)) != null)
            ret.Add(temp);
        if((temp = GetNeightborTile(tile, Direction.Left)) != null)
            ret.Add(temp);
        if((temp = GetNeightborTile(tile, Direction.Right)) != null)
            ret.Add(temp);
        if((temp = GetNeightborTile(tile, Direction.Up)) != null)
            ret.Add(temp);
        return ret;
    }

    public static TileBase GetNearestTile(Vector3 position)
    {
        TileBase ret = null;
        float distance = float.MaxValue;
        foreach(TileBase[] arr in Map.sSingleton.tiles_)
        {
            foreach (TileBase tile in arr) 
            {
                var temp = Vector3.Distance(tile.transform.position, position);
                if (temp < distance)
                {
                    ret = tile;
                    distance = temp;
                }
            }
        }
        return ret;
    }

    public static TileBase GetNeightborTile(TileBase tile, Direction direction)
    {
        switch (direction)
        {
            case Direction.Down: return GetDownNeighbor(tile);
            case Direction.Left: return GetLeftNeighbor(tile);
            case Direction.Right: return GetRightNeighbor(tile);
            case Direction.Up: return GetUpNeighbor(tile);
            default: Debug.LogError("wtf direction"); return GetDownNeighbor(tile);
        }
    }

    private static TileBase GetRightNeighbor(TileBase tile)
    {
            int x = tile.position_.x, y = tile.position_.y;
        try
        {
            if (y < Map.sSingleton.tiles_[x].Length - 1)
                return Map.sSingleton.tiles_[x][y + 1];
            return null;
        }
        catch { Debug.Log(Map.sSingleton.tiles_.Length + "   " + Map.sSingleton.tiles_[x].Length); Debug.LogError(x + "  " + y); return null; }
    }
    private static TileBase GetLeftNeighbor(TileBase tile)
    {
        int x = tile.position_.x, y = tile.position_.y;
        if (y > 0)
            return Map.sSingleton.tiles_[x][y - 1];
        return null;
    }
    private static TileBase GetUpNeighbor(TileBase tile)
    {
        int x = tile.position_.x, y = tile.position_.y;
        if (x > 0)
            return Map.sSingleton.tiles_[x - 1][y];
        return null;
    }
    private static TileBase GetDownNeighbor(TileBase tile)
    {
        int x = tile.position_.x, y = tile.position_.y;
        if (x < Map.sSingleton.tiles_[x].Length - 1)
            return Map.sSingleton.tiles_[x + 1][y];
        return null;
    }
}
