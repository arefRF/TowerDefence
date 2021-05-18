using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    public TileType type_;
    [SerializeField]
    private MeshRenderer mesh_;

    public Vector2Int position_;

    public bool is_visited_ = false;
    public Direction road_exit_direction;
    public bool is_in_loop_;
    public bool is_node;
    public int number_ = -1;

    public List<TileBase> edge_sink_list_ = new List<TileBase>();

    public void ChangeTileType(TileType type)
    {
        Material material = null;
        foreach (var matset in MaterialStaticDataContainer.sSingleton.pTileMaterials)
        {
            if(matset.type_ == type)
            {
                material = matset.material_;
                break;
            }
        }
        type_ = type;
        mesh_.material = material;
    }

}

public enum TileType
{
    Road, Crystal, Ground, Goal, Spawner, None
}

public enum Direction
{
    Right,Left,Up,Down
}

public enum HexDirection
{
    UpLeft, UpRight, Left, Right, DownLeft, DownRight
}
