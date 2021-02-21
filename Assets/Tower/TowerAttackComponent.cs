using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackComponent : MonoBehaviour
{
    private TowerBase tower_;
    private TowerStatComponent stat_;
    private RangeWeapon weapon_;

    private EnemyBase target_;
    public void Start()
    {
        InitializeOnStart();
    }

    public void Update()
    {
        UpdateState();
    }

    public void InitializeOnStart()
    {
        tower_ = GetComponent<TowerBase>();
        stat_ = tower_.pStatComponent;
        weapon_ = tower_.pWeapon;
        stat_.pTimeToNextAttack = stat_.pAttackTime;
    }

    public void UpdateState()
    {
        stat_.pTimeToNextAttack -= Time.deltaTime;
        if(stat_.pTimeToNextAttack <= 0)
        {
            stat_.pTimeToNextAttack = stat_.pAttackTime;
            Shoot();
        }
    }

    private void Shoot()
    {
        AcquireTarget();
        if(target_ != null)
            weapon_.Shoot(target_.gameObject);
    }

    private void AcquireTarget()
    {
        target_ = EnemyManager.sSingletone.GetRandomEnemy();
    }
}
