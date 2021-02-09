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

    public TileBase[][] tiles_;
    private Vector2Int map_size_;
    private TileBase[] children_;
    // Start is called before the first frame update
    void Start()
    {
        MakeMap();
        PrintMap();
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
        map_size_  = new Vector2Int((int)Mathf.Sqrt(children_.Length), (int)Mathf.Sqrt(children_.Length));
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
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for(int k = 0; k < children_.Length; k++)
                    {
                        if((int)children_[k].transform.position.x == (int)tiles_[i][j-1].transform.position.x)
                        {
                            if((int)children_[k].transform.position.z == (int)tiles_[i][j - 1].transform.position.z + tile_size_)
                            {
                                tiles_[i][j] = children_[k];
                                break;
                            }
                        }
                    }
                }
            }
        }
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
}
