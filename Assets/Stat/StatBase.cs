using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatBase
{
    public StatEnum stat_enum_;
    public float value_;
}

public enum StatEnum
{
    HP = 1,
    Damage = 2,
    AttackTime = 3,
    StartingSpeed = 4,
    Acceleration = 5,
    MaxSpeed = 6,
    RotationSpeed = 7,
    ReachDistance = 8,
    Interval = 9,
    Count = 10,
    Radius = 11,
    DamageMultiplier = 12,
    
}
