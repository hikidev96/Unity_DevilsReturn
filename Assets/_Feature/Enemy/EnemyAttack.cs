using UnityEngine;
using Animancer;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class EnemyAttack : BaseMonoBehaviour
    {
        [SerializeReference] private ITransition _animation;
        [SerializeField] private float range = 1.0f;
        [SerializeField] private float baseDamage = 5.0f;

        public ITransition Animation => _animation;
        public float Range => range;
        public float BaseDamage => baseDamage;  

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, range);
        }
    }
}