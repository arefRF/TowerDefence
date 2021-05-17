using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sSingleton;
    public GameMode game_mode_;

    private void Awake()
    {
        sSingleton = this;
        game_mode_ = GameMode.Play;
    }


    public void TabPressed()
    {
        if (game_mode_ == GameMode.Play)
        {
            game_mode_ = GameMode.UI;
            PlayTabUI();

        }
        else if (game_mode_ == GameMode.UI)
        {
            game_mode_ = GameMode.Play;
            StopTabUI();
        }
    }

    public void PlayTabUI()
    {
        var tiles = Map.sSingleton.placable_tiles_;
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].ShowTile();
        }
    }

    public void StopTabUI()
    {
        var tiles = Map.sSingleton.placable_tiles_;
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].HideTile();
        }
    }

    public void LeftMouseClicked()
    {
        var hit = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.tag == "TileUI")
                {
                    TileSelected(hit[i].collider.gameObject);
                }
            }
        }
    }

    public void RightMouseClicked()
    {
        var hit = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.tag == "TileUI")
                {
                    TileDeselected(hit[i].collider.gameObject);
                }
            }
        }
    }

    public void TileSelected(GameObject tile) 
    {
        if (game_mode_ == GameMode.UI)
            TowerManager.sSingleton.DeployTowerAt(tile);
    }
    public void TileDeselected(GameObject tile)
    {
        if (game_mode_ == GameMode.UI)
            TowerManager.sSingleton.UnDeployTowerAt(tile);
    }

    public void TriggerLosecondition()
    {
        Debug.LogError("you lost");
    }
}
public enum GameMode
{
    Pause, Play, UI
}
