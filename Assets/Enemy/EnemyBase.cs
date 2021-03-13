using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    private StatComponent stats_;
    public StatComponent pStats { get { return stats_; } }
    private EnemyHealthComponent health_;
    public EnemyHealthComponent pHealth { get { return health_; } }

    private MoveTest move_component_;
    public MoveTest pMoveComponent { get { return move_component_;} }

    public Delegate_NoArgument OnRelease;
    void Awake()
    {
        stats_ = GetComponent<StatComponent>();
        health_ = GetComponent<EnemyHealthComponent>();
        move_component_ = GetComponent<MoveTest>();
    }

    void Update()
    {
        
    }

    public void Release()
    {
        OnRelease?.Invoke();
        EnemyManager.sSingleton.RemoveEnemyFromList(this);
        Destroy(gameObject);
    }
}
