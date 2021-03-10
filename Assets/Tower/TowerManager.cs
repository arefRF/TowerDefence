using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager sSingleton { get; private set; }
    [SerializeField]
    private List<TowerBase> undeployed_towers_list_;
    [SerializeField]
    private List<TowerBase> deployed_towers_list_;
    [SerializeField]
    private List<TowerBase> towers_list_;
    public List<TowerBase> pTowers { get { return towers_list_; } }
    private void Awake()
    {
        sSingleton = this;
        for (int i = 0; i < towers_list_.Count; i++)
            undeployed_towers_list_.Add(towers_list_[i]);
    }

    public TowerBase GetUndeployedTowerAt(Vector3 position)
    {
        for(int i=0; i< undeployed_towers_list_.Count; i++)
        {
            if (undeployed_towers_list_[i].transform.position == position)
                return undeployed_towers_list_[i];
        }
        return null;
    }
    public TowerBase GetUndeployedTowerAt(UITileController ui_tile)
    {
        for (int i = 0; i < undeployed_towers_list_.Count; i++)
        {
            if (undeployed_towers_list_[i].pUITile == ui_tile)
                return undeployed_towers_list_[i];
        }
        return null;
    }

    public TowerBase GetDeployedTowerAt(Vector3 position)
    {
        for (int i = 0; i < deployed_towers_list_.Count; i++)
        {
            if (deployed_towers_list_[i].transform.position == position)
                return deployed_towers_list_[i];
        }
        return null;
    }
    public TowerBase GetDeployedTowerAt(UITileController ui_tile)
    {
        for (int i = 0; i < deployed_towers_list_.Count; i++)
        {
            if (deployed_towers_list_[i].pUITile == ui_tile)
                return deployed_towers_list_[i];
        }
        return null;
    }

    public void DeployTowerAt(GameObject tile)
    { 
        var ui_tile = tile.GetComponent<UITileController>();
        if (ui_tile.pType == TileType.Ground && undeployed_towers_list_.Count > 0 && GetDeployedTowerAt(ui_tile) == null)
        {
            var tower = undeployed_towers_list_[0];
            deployed_towers_list_.Add(tower);
            undeployed_towers_list_.Remove(tower);
            tower.DeployTower(ui_tile);
        }
    }

    public void UnDeployTowerAt(GameObject tile)
    {
        var ui_tile = tile.GetComponent<UITileController>();
        var tower = GetDeployedTowerAt(ui_tile);
        if(tower != null)
        {
            deployed_towers_list_.Remove(tower);
            undeployed_towers_list_.Add(tower);
            tower.UndeployTower();
        }
    }

    public List<TowerBase> GetAllTowersInRadius(Vector3 center_position, float radius)
    {
        List<TowerBase> towers = new List<TowerBase>();
        foreach(var tower in towers_list_)
        {
            if(Vector3.Distance(center_position, tower.transform.position) <= radius + Mathf.Epsilon)
            towers.Add(tower);
        }
        return towers;
    }
}
