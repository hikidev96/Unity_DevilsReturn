using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    public class EnemyProjectileAttack : EnemyAttack
    {
        [SerializeField] private List<Transform> firePoints;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private GameObject projectileFireFXPrefab;

        public void Attack()
        {
            StartCoroutine(StartCoolTime());

            for (int i = 0; i < firePoints.Count; ++i)
            {
                var projectileFireFXObj = Instantiate(projectileFireFXPrefab, firePoints[i].position, Quaternion.identity);
                projectileFireFXObj.transform.forward = VectorHelper.GetExceptYFrom(firePoints[i].forward);

                var projectileObj = Instantiate(projectilePrefab, firePoints[i].position, Quaternion.identity);
                projectileObj.transform.forward = VectorHelper.GetExceptYFrom(firePoints[i].forward);

                var projectile = projectileObj.GetComponent<Projectile>();
                projectile.SetDamage(baseDamage);                
            }
        }
    }
}
