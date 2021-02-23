using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    private EnemyStatComponent stats_;
    public EnemyStatComponent pStats { get { return stats_; } }
    private EnemyHealthComponent health_;
    public EnemyHealthComponent pHealth { get { return health_; } }
    void Start()
    {
        stats_ = GetComponent<EnemyStatComponent>();
        health_ = GetComponent<EnemyHealthComponent>();
    }

    void Update()
    {
        
    }
}
