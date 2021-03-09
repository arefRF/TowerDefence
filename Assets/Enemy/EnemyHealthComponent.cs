using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour
{
    private EnemyBase enemy_;
    
    void Start()
    {
        enemy_ = GetComponent<EnemyBase>();
    }
    public void DoDamage(float damage)
    {
        VFXManager.sSingleton.InstantiateAndPlayVFX(StaticVFXContainer.sSingleton.pEnemyHitVFX, transform.position, transform.rotation);
        enemy_.pStats.IncrementStat(EnemyStatEnum.HP, -damage);
        var hp = enemy_.pStats.FindStat(EnemyStatEnum.HP).value_;
        if(hp <= 0)
            Die();
    }

    public void Die()
    {
        EnemyManager.sSingletone.RemoveEnemyFromList(GetComponent<EnemyBase>());
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
