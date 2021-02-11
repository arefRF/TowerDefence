using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    public TileBase[] tiles_;
    public List<TileBase> roads_;
    public List<TileBase> spawners_;
    public List<NodePoint> nodes_;

    public void MakeMap()
    {
        roads_ = new List<TileBase>();
        spawners_ = new List<TileBase>();
        for(int i = 0; i < tiles_.Length; i++)
        {
            switch(tiles_[i].type_)
            {
                case TileType.Road : roads_.Add(tiles_[i]); break;
                case TileType.Spawner: spawners_.Add(tiles_[i]); break;
            }
        }

    }

    public void MakeNodes()
    {

    }
}
