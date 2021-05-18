using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject raw_tile_hex_;

    [SerializeField]
    private float x_distance_;
    [SerializeField]
    private float z_distance_;
    [SerializeField]
    private int x_count_,z_count_;
    [SerializeField]
    private Vector3 start_pos_;


    [SerializeField]
    private TileType tile_type_;
    public TileType pTileType { get { return tile_type_; } }

    private List<GameObject> hex_list = new List<GameObject>();

    [HideInInspector]
    public bool is_registered_;
    [HideInInspector]
    public bool is_edit_mode_;
    [HideInInspector]
    public int selected_ = 0;

    public TileBase[][] tiles_matrix_;

    public void GenerateMap()
    {
        Clear();
        tiles_matrix_ = new TileBase[z_count_][];
        for (int j = 0; j < z_count_; j++)
        {
            tiles_matrix_[j] = new TileBase[x_count_];
            for (int i = 0; i <x_count_; i++)
            {
                var pos = start_pos_ + new Vector3(i * x_distance_ + (j % 2) * (x_distance_ / 2), 0, j * z_distance_);
                var obj = Instantiate(raw_tile_hex_, pos, Quaternion.identity, transform);
                var tile = obj.GetComponent<TileBase>();
                tile.ChangeTileType(TileType.Ground);
                tiles_matrix_[j][i] = tile;
                hex_list.Add(obj);
            }
        }
    }

    private TileType GetTileType(int num)
    {
        TileType tile_type;
        switch (num)
        {
            case -1: tile_type = TileType.None; break;
            case 0: tile_type = TileType.Ground; break;
            case 1: tile_type = TileType.Goal; break;
            case 2: tile_type = TileType.Crystal; break;
            case 3: tile_type = TileType.Road; break;
            case 4: tile_type = TileType.Spawner; break;
            default: tile_type = TileType.Ground; break;
        }
        return tile_type;
    }
    public void Clear()
    {
        for(int i=0; i<hex_list.Count; i++)
        {
            DestroyImmediate(hex_list[i]);
        }
        hex_list.Clear();
    }

    public void ChangeTileType(TileBase tile, bool change_to_none = false)
    {
        if (change_to_none)
            tile.ChangeTileType(TileType.None);
        else
            tile.ChangeTileType(GetTileType(selected_));
    }
}
