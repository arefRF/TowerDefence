using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager sSingleton;
    [SerializeField]
    private List<TowerBase> undeployed_towers_list_;
    [SerializeField]
    private List<TowerBase> deployed_towers_list_;


    private void Awake()
    {
        sSingleton = this;

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

    public TowerBase GetDeployedTowerAt(Vector3 position)
    {
        for (int i = 0; i < deployed_towers_list_.Count; i++)
        {
            if (deployed_towers_list_[i].transform.position == position)
                return deployed_towers_list_[i];
        }
        return null;
    }

    public void DeployTowerAt(GameObject tile)
    {
        if (undeployed_towers_list_.Count > 0 && GetDeployedTowerAt(tile.transform.position) == null)
        {
            var tower = undeployed_towers_list_[0];
            deployed_towers_list_.Add(tower);
            undeployed_towers_list_.Remove(tower);
            tower.DeployTower(tile);
        }
    }

    public void UnDeployTowerAt(GameObject tile)
    {
        var tower = GetDeployedTowerAt(tile.transform.position);
        if(tower != null)
        {
            deployed_towers_list_.Remove(tower);
            undeployed_towers_list_.Add(tower);
            tower.UndeployTower();
        }
    }
}
