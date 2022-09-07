using System.Collections;
using UnityEngine;
using Animancer;

namespace DevilsReturn
{
    public class EnemyAttack : BaseMonoBehaviour
    {
        [SerializeReference] private ITransition _animation;
        [SerializeField] protected float range = 1.0f;
        [SerializeField] protected float baseDamage = 5.0f;
        [SerializeField] protected float coolTime = 5.0f;

        private bool isOverCoolTime = true;

        public ITransition Animation => _animation;
        public float Range => range;
        public float BaseDamage => baseDamage;
        public bool IsOverCoolTime => isOverCoolTime;   

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, range);
        }

        protected IEnumerator StartCoolTime()
        {
            isOverCoolTime = false;
            yield return new WaitForSeconds(coolTime);
            isOverCoolTime = true;
        }
    }
}