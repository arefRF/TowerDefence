using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITileController : MonoBehaviour
{
    [SerializeField]
    private GameObject green_tile;
    [SerializeField]
    private GameObject red_tile;
    [SerializeField]
    private GameObject black_tile;

    [SerializeField]
    private TileType type_;
    public TileType pType { get { return type_; } }

    public void Initialize(TileType type)
    {
        type_ = type;
        green_tile.SetActive(false);
        red_tile.SetActive(false);
        black_tile.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ShowTile()
    {
        gameObject.SetActive(true);
        if (type_ == TileType.Ground)
        {
            if (TowerManager.sSingleton.GetDeployedTowerAt(transform.position) != null)
                red_tile.SetActive(true);
            else
                green_tile.SetActive(true);
        }
        else
            black_tile.SetActive(true);
    }

    public void HideTile()
    {
        black_tile.SetActive(false);
        red_tile.SetActive(false);
        green_tile.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Refresh()
    {
        Initialize(type_);
        ShowTile();
    }
}
