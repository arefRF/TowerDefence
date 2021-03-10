using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDPSWeaponComponent : MonoBehaviour
{
    private StatComponent stat_;
    private ParticleSystem particle_system_;
    private int timer_id_;
    public void Initialize()
    {
        stat_ = GetComponent<StatComponent>();
        particle_system_ = GetComponentInChildren<ParticleSystem>();
    }

    public void StartWeapon()
    {
        Timer.RegisterTimer_NoArgumentEvent(DoDamage, stat_.FindStat(StatEnum.Interval).value_, -1, out timer_id_);
        particle_system_.Play();
    }

    public void StopWeapon()
    {
        Timer.UnregisterTimer(timer_id_);
        particle_system_.Stop();
        Destroy(gameObject);
    }

    private void DoDamage()
    {
        var towers = TowerManager.sSingleton.GetAllTowersInRadius(transform.position, stat_.FindStat(StatEnum.Radius).value_);
        var damage = stat_.FindStat(StatEnum.Damage).value_;
        foreach (var tower in towers)
            tower.pHealthComponent.DoDamage(damage);
    }
}
