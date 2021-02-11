using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private TileBase first_tile_;
    [SerializeField]
    private GameObject tiles_parent_;
    [SerializeField]
    private int tile_size_;
    [SerializeField]
    private GameObject node_stone_;
    [SerializeField]
    private GameObject node_stone_parent;

    public TileBase[][] tiles_;
    [SerializeField]
    private Vector2Int map_size_;
    private TileBase[] children_;

    [SerializeField]
    private TileBase[] spawners_;
    // Start is called before the first frame update
    void Start()
    {
        MakeMap();
        //PrintMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PrintMap()
    {
        for(int i=0; i<map_size_.x; i++)
        {
            Debug.LogError("Row: " + i);
            for(int j=0; j<map_size_.y; j++)
            {
                Debug.Log(tiles_[i][j].transform.position, tiles_[i][j].gameObject);
            }
        }
    }

    private void MakeMap()
    {
        children_ = tiles_parent_.GetComponentsInChildren<TileBase>();
        //map_size_  = new Vector2Int((int)Mathf.Sqrt(children_.Length), (int)Mathf.Sqrt(children_.Length));
        tiles_ = new TileBase[map_size_.x][];
        for(int i=0; i<map_size_.x; i++)
        {
            tiles_[i] = new TileBase[map_size_.y];
        }
        tiles_[0][0] = first_tile_;
        for(int i=0; i<map_size_.x; i++)
        {
            for(int j=0; j<map_size_.y; j++)
            {
                if(i==0 && j==0)
                    continue;
                if(j == 0)
                {
                    for(int k = 0; k < children_.Length; k++)
                    {
                        if((int)children_[k].transform.position.z == (int)tiles_[i-1][j].transform.position.z)
                        {
                            if((int)children_[k].transform.position.x == (int)tiles_[i-1][j].transform.position.x + tile_size_)
                            {
                                tiles_[i][j] = children_[k];
                                children_[k].position_ = new Vector2Int(i, j);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for(int k = 0; k < children_.Length; k++)
                    {
                        if ((int)children_[k].transform.position.x == (int)tiles_[i][j - 1].transform.position.x)
                        {
                            if ((int)children_[k].transform.position.z == (int)tiles_[i][j - 1].transform.position.z + tile_size_)
                            {
                                tiles_[i][j] = children_[k];
                                children_[k].position_ = new Vector2Int(i, j);
                                break;
                            }
                        }
                    }
                }
            }
        }

        GenerateGraphFromTileBase();
    }

    private Vector2Int GetMapSize()
    {
        int x = int.MinValue, y = int.MinValue;
        children_ = tiles_parent_.GetComponentsInChildren<TileBase>();
        for(int i=0; i< children_.Length; i++)
        {
           if((int)children_[i].transform.position.x > x)
                x = (int)children_[i].transform.position.x;
            if((int)children_[i].transform.position.y > y)
                y = (int)children_[i].transform.position.y;
        }
        return new Vector2Int(x,y);
    }

    public TileBase GetTileInPosition(Vector2Int position)
    {
        Debug.LogError("returning tile with position: " + tiles_[position.x / tile_size_][position.y / tile_size_]);
        return tiles_[position.x / tile_size_][position.y / tile_size_];
    }

    public void GenerateGraphFromTileBase()
    {
        var dirs = new Direction[] { Direction.Down, Direction.Left, Direction.Right, Direction.Up };
        var queue = new Queue<TileBase>();
        foreach (var item in spawners_)
            queue.Enqueue(item);
        while(queue.Count > 0)
        {
            int neighbor_count = 0;
            var item = queue.Dequeue();
            for(int i=0; i<dirs.Length; i++)
            {
                TileBase n_tile = GetNeightborTile(item, dirs[i]);
                if (null != n_tile && !n_tile.is_visited_)
                {
                    queue.Enqueue(n_tile);
                    n_tile.is_visited_ = true;

                    if (dirs[i] != item.road_exit_direction)
                    {
                        n_tile.road_exit_direction = dirs[i];
                        if(neighbor_count == 0)
                            MakeTileNode(item);
                        neighbor_count++;
                    }
                    else
                        n_tile.road_exit_direction = item.road_exit_direction;
                }
            }
        }
    }

    private void MakeTileNode(TileBase tile)
    {
        var go = Instantiate(node_stone_, tile.transform.position, tile.transform.rotation, node_stone_parent.transform);
    }

    private TileBase GetNeightborTile(TileBase tile, Direction direction)
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

    private TileBase GetRightNeighbor(TileBase tile)
    {
            int x = tile.position_.x, y = tile.position_.y;
        try
        {
            if (y < tiles_[x].Length - 1 && tiles_[x][y + 1].type_ == TileType.Road)
                return tiles_[x][y + 1];
            return null;
        }
        catch { Debug.Log(tiles_.Length + "   " + tiles_[x].Length); Debug.LogError(x + "  " + y); return null; }
    }
    private TileBase GetLeftNeighbor(TileBase tile)
    {
        int x = tile.position_.x, y = tile.position_.y;
        if (y > 0 && tiles_[x][y - 1].type_ == TileType.Road)
            return tiles_[x][y - 1];
        return null;
    }
    private TileBase GetUpNeighbor(TileBase tile)
    {
        int x = tile.position_.x, y = tile.position_.y;
        if (x > 0 && tiles_[x - 1][y].type_ == TileType.Road)
            return tiles_[x - 1][y];
        return null;
    }
    private TileBase GetDownNeighbor(TileBase tile)
    {
        int x = tile.position_.x, y = tile.position_.y;
        if (x < tiles_[x].Length - 1 && tiles_[x + 1][y].type_ == TileType.Road)
            return tiles_[x + 1][y];
        return null;
    }
}
