using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager sSingleton;

    [SerializeField]
    private float hp_multiplier_;
    [SerializeField]
    private int hp_multiply_interval_;
    [SerializeField]
    private float spawn_rate_multiplier_;
    [SerializeField]
    private int spawn_rate_multiply_interval_;

    private int spawned_count_;

    public float pHPMultiplier { get; private set; }
    public float pSpawnRateMultiplier { get; private set; }
    void Start()
    {
        sSingleton = this;
        spawned_count_ = 0;
        pHPMultiplier = 1;
        pSpawnRateMultiplier = 2;
    }

    public void EnemySpawned()
    {
        spawned_count_++;
        if(spawned_count_ % hp_multiply_interval_ == 0)
            pHPMultiplier *= hp_multiplier_;
        if(spawned_count_ % spawn_rate_multiply_interval_ == 0)
            pSpawnRateMultiplier *= spawn_rate_multiplier_;
    }


}
