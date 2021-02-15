using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hive.Projectile
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/ProjectileData", order = 1)]
    public class ProjectileDataAsset : ScriptableObject
    {
        [SerializeField]
        public float starting_speed_;
        [SerializeField]
        public float target_speed_;
        [SerializeField]
        public float acceleration_;
        [SerializeField]
        public float rotation_speed_;
        [SerializeField]
        public float reach_distance_;
    }
}
