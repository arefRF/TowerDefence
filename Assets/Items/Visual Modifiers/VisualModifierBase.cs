using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class BulletVisualModifierBase : MonoBehaviour
{
    protected BulletVisualModifierEnum visual_enum_;
    public BulletVisualModifierEnum pVisualEnum {  get { return visual_enum_; } }

    protected ProjectileBase bullet_;
    public virtual void Initialize(ProjectileBase bullet)
    {
        bullet_ = bullet;
        RegisterStartCallBack();
        RegisterUpdateCallBack();
        RegisterHitCallBack();
    }

    public virtual void RegisterStartCallBack() { }
    public virtual void RegisterUpdateCallBack() { }
    public virtual void RegisterHitCallBack() { }
}

public enum BulletVisualModifierEnum
{
    MakeBigger = 1,

}
