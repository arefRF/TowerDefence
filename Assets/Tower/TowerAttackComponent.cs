using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class TowerAttackComponent : MonoBehaviour
{
    private TowerBase tower_;
    private StatComponent stats_;
    private RangeWeapon weapon_;

    private EnemyBase target_;

    [SerializeField]
    private float time_to_next_attack_;

    private bool pCanshoot;

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
        pCanshoot = true;
    }

    public void UpdateState()
    {
        time_to_next_attack_ -= Time.deltaTime;
        if(time_to_next_attack_ <= 0)
        {
            time_to_next_attack_ = stats_.FindStat(StatEnum.AttackTime).value_;
            if(pCanshoot)
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
        target_ = EnemyManager.sSingleton.GetRandomEnemy();
    }

}
