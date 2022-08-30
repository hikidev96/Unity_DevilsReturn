using UnityEngine;

namespace DevilsReturn
{
    public class AttackDamageData : BaseMonoBehaviour
    {
        [SerializeField] private float AttackDamageBase = 1.0f;

        private float AttackDamageVariance = 1.0f;

        public float AttackDamage => AttackDamageBase * AttackDamageVariance;

        public void AddAttackDamageBase(float amount)
        {
            AttackDamageBase += amount;
        }

        public void AddAttackDamageVariance(float amount)
        {
            AttackDamageVariance += amount;
        }
    }
}
