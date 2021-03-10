using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackComponent_DarkSplash : MonoBehaviour
{
    private EnemyBase enemy_;
    private StatComponent stat_;

    private float last_attack_time_;
    private float interval_;
    private List<AreaDPSWeaponComponent> dps_components_;
    void Start()
    {
        enemy_ = GetComponent<EnemyBase>();
        enemy_.pMoveComponent.OnDestinationchanged += Attack;
        enemy_.OnRelease += OnRelease;
        dps_components_ = new List<AreaDPSWeaponComponent>();
    }

    private void OnRelease()
    {
        ClearPrevAttacks();
    }

    public void Attack()
    {
        ClearPrevAttacks();
        var this_tile = MapTools.GetNearestTile(transform.position);
        var neighbors = MapTools.GetNeighborTiles(this_tile);
        foreach (var tile in neighbors)
        {
            if(tile.type_ == TileType.Ground)
            {
                var component = Instantiate(StaticDataContainer.sSingleton.pDarkAuraPrefab, tile.transform.position, tile.transform.rotation).GetComponent<AreaDPSWeaponComponent>();
                component.Initialize();
                component.StartWeapon();
                dps_components_.Add(component);
            }
        }
    }

    private void ClearPrevAttacks()
    {
        foreach(var component in dps_components_)
            component.StopWeapon();
        dps_components_.Clear();
    }
}
