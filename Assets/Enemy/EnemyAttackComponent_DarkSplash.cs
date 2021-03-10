using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackComponent_DarkSplash : MonoBehaviour
{
    private EnemyBase enemy_;
    private EnemyStatComponent stat_;

    private float last_attack_time_;
    private float interval_;
    void Start()
    {
        enemy_ = GetComponent<EnemyBase>();
        stat_ = enemy_.pStats;
        last_attack_time_ = Time.time;
        interval_ = stat_.FindStat(StatEnum.Interval).value_;
    }

    void Update()
    {
        if(last_attack_time_ + interval_ >= Time.time) 
        {
            last_attack_time_ = Time.time;
            Attack();
        }
    }

    private void Attack() 
    {
        var tiles = MapTools.GetNeighborTiles(transform.position, Map.sSingleton.tile_size_);
        for(int i=0; i < tiles.Count; i++) 
        {

        }
    }
}
