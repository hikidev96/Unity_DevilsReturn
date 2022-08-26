using UnityEngine;
using Animancer;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public enum EEnemyAttackType
    {
        Melee,
        Projectile
    }

    public class EnemyAttack : BaseMonoBehaviour
    {
        [SerializeReference] private ITransition _animation;
        [SerializeField] private EEnemyAttackType attackType;
        [SerializeField, ShowIf("@attackType==EEnemyAttackType.Projectile")] private Transform firePoint;
        [SerializeField, ShowIf("@attackType==EEnemyAttackType.Projectile")] private GameObject projectilePrefab;
        [SerializeField, ShowIf("@attackType==EEnemyAttackType.Projectile")] private GameObject projectileFirePrefab;
        [SerializeField] private float range = 1.0f;
        [SerializeField] private float baseDamage = 5.0f;

        public ITransition Animation => _animation;
        public EEnemyAttackType AttackType => attackType;
        public Transform FirePoint => firePoint;    
        public GameObject ProjectilePrefab => projectilePrefab;
        public GameObject ProjectileFirePrefab => projectileFirePrefab;
        public float Range => range;
        public float BaseDamage => baseDamage;  

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, range);
        }
    }
}