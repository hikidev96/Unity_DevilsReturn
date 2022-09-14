using UnityEngine;

namespace DevilsReturn
{
    public class AttackData : BaseMonoBehaviour
    {
        [SerializeField] private float damageBase = 1.0f;

        private float damageVariance = 1.0f;
        private float criticalChance = 0.0f;
        private float criticalDamage = 10.0f;

        public float Damage => damageBase * damageVariance;
        public float CriticalChance => criticalChance;
        public float CriticalDamage => (1 + criticalDamage / 100);

        public void AddDamageBase(float amount)
        {
            damageBase += amount;
        }

        public void AddDamageVariance(float amount)
        {
            damageVariance += amount;
        }

        public void AddCriticalChance(float amount)
        {
            criticalChance += amount;

            criticalChance = Mathf.Clamp(criticalChance, 0.0f, 100.0f);
        }

        public void AddCriticalDamage(float amount)
        {
            criticalDamage += amount;
        }
    }
}