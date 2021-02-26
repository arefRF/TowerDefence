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
    HP, Damage, AttackTime, StartingSpeed, Acceleration, MaxSpeed, RotationSpeed, ReachDistance 
}
