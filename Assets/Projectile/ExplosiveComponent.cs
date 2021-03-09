using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveComponent : MonoBehaviour
{
    private ProjectileStat stat_;
    private VFXEventHandler event_handler_;

    private ParticleSystem particle_system_;
    // Start is called before the first frame update
    public void Initialize()
    {
        stat_ = GetComponent<ProjectileStat>();
        event_handler_ = GetComponent<VFXEventHandler>();
        particle_system_ = GetComponentInChildren<ParticleSystem>();
    }

    private void DamageCallBack()
    {
        var enemies = EnemyManager.sSingletone.GetAllEnemiesInRadius(transform.position, stat_.FindStat(StatEnum.Radius).value_);
        var damage = stat_.FindStat(StatEnum.Damage).value_;
        for(int i=0; i < enemies.Count; i++)
        {
            enemies[i].pHealth.DoDamage(damage);
        }
    }

    public void Explode(float radius, float damage)
    {
        Initialize();
        stat_.FindStat(StatEnum.Radius).value_ = radius;
        stat_.FindStat(StatEnum.Damage).value_ = damage;
        event_handler_.RegisterEvent(DamageCallBack, VFXEventEnum.DoDamage);
        particle_system_.Play();
    }
}
