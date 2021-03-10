using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatComponent : MonoBehaviour
{
    [SerializeField]
    private List<EnemyStatBase> stats_;

     public EnemyStatBase FindStat(StatEnum stat_enum)
    {
        for(int i=0; i<stats_.Count; i++)
        {
            if(stats_[i].stat_enum_ == stat_enum)
                return stats_[i];
        }
        Debug.LogError("stat not found. Stat: " + stat_enum);
        return null;
    }

    public void MultiplyStat(StatEnum stat_enum, float multiplier)
    {
        var stat = FindStat(stat_enum);
        if(stat != null)
            stat.value_ *= multiplier;
    }

    public void IncrementStat(StatEnum stat_enum, float value)
    {
        var stat = FindStat(stat_enum);
        if(stat != null)
            stat.value_ += value;
    }
}

[System.Serializable]
public class EnemyStatBase
{
    public StatEnum stat_enum_;
    public float value_;
}
