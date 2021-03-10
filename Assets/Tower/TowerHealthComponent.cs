using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthComponent : MonoBehaviour
{
    private TowerBase tower_;
    
    void Start()
    {
        tower_ = GetComponent<TowerBase>();
    }
    public void DoDamage(float damage)
    {
        VFXManager.sSingleton.InstantiateAndPlayVFX(StaticVFXContainer.sSingleton.pEnemyHitVFX, transform.position, transform.rotation);
        tower_.pStatComponent.IncrementStat(StatEnum.HP, -damage);
        var hp = tower_.pStatComponent.FindStat(StatEnum.HP).value_;
        if(hp <= 0)
            Die();
    }

    public void Die()
    {
        Debug.LogError("TOWER IS DEAD");
    }
}
