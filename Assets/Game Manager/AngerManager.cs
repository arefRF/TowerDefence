using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerManager : MonoBehaviour
{
    public static AngerManager sSingleton;
    [SerializeField]
    private int max_enemy_count_;
    public int pMaxEnemyCount { get { return max_enemy_count_; } }
    private int current_enemy_count_;
    public int pCurrentEnemyCount { get { return current_enemy_count_; } }
    void Start()
    {
        sSingleton = this;
        current_enemy_count_ = 0;
    }

    public void EnemyReachedNextDestination(EnemyBase enemy)
    {
        if(!MapTools.GetNearestTile(enemy.transform.position).is_in_loop_)
            return;
        current_enemy_count_++;
        if(current_enemy_count_ >= max_enemy_count_)
            GameManager.sSingleton.TriggerLosecondition();
    }

    public void EnemyDied(EnemyBase enemy)
    {
        if(MapTools.GetNearestTile(enemy.transform.position).is_in_loop_)
            current_enemy_count_--;
    }
}
