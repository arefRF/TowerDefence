using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class TowerAttackComponent : MonoBehaviour
{
    private TowerBase tower_;
    private TowerStatComponent stats_;
    private RangeWeapon weapon_;

    private EnemyBase target_;

    [SerializeField]
    private float time_to_next_attack_;

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
        stats_ = tower_.pStatComponent;
        weapon_ = tower_.pWeapon;
        time_to_next_attack_ = stats_.FindStat(StatEnum.AttackTime).value_;
    }

    public void UpdateState()
    {
        time_to_next_attack_ -= Time.deltaTime;
        if(time_to_next_attack_ <= 0)
        {
            time_to_next_attack_ = stats_.FindStat(StatEnum.AttackTime).value_;
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
