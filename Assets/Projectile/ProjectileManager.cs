using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hive.Projectile {
    public class ProjectileManager : MonoBehaviour
    {
        private static ProjectileManager singleton_;
        public static ProjectileManager sSingleton { get { return singleton_; } }
        private List<ProjectileBase> active_projectiles_;
        private void Awake()
        {
            singleton_ = this;
            active_projectiles_ = new List<ProjectileBase>(50);
        }
        public void AddProjectile(ProjectileBase projectile) 
        {
            active_projectiles_.Add(projectile);
        }
        private void Update()
        {
            UpdateProjectilesMovement();
        }
        private void UpdateProjectilesMovement()
        {
            var delta_time = Time.deltaTime;
            for(int i = 0; i < active_projectiles_.Count; i++)
            {
                if (active_projectiles_[i].UpdateMovement(delta_time))
                {
                    active_projectiles_[i].OnHit();
                    active_projectiles_.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
