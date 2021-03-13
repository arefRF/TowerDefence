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
        enemy_.pStats.IncrementStat(StatEnum.HP, -damage);
        var hp = enemy_.pStats.FindStat(StatEnum.HP).value_;
        UIManager.sSingleton.CreateDamageNumber(transform.position, (int)damage);
        if(hp <= 0)
            Die();
    }

    public void Die()
    {
        EnemyManager.sSingleton.RemoveEnemyFromList(enemy_);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
