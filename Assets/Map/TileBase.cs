using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    public TileType type_;

    public Vector2Int position_;

    public bool is_visited_ = false;
    public Direction road_exit_direction;
    public bool is_in_loop_;
    public bool is_node;
    public int number_ = -1;

    public List<TileBase> edge_sink_list_ = new List<TileBase>();

}

public enum TileType
{
    Road, Crystal, Ground, Goal, Spawner
}

public enum Direction
{
    Right,Left,Up,Down
}
