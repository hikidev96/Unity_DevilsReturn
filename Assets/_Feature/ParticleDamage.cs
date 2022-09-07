using UnityEngine;

namespace DevilsReturn
{
    public class ParticleDamage : BaseMonoBehaviour
    {
        [SerializeField] private EFaction damageTo;
        [SerializeField] private float damage;

        public void SetDamage(float damage)
        {
            this.damage = damage;
        }

        private void OnParticleCollision(GameObject other)
        {
            var healthPoint = other.GetComponent<HealthPoint>();

            if (healthPoint != null && healthPoint.Faction == damageTo)
            {
                healthPoint.Damage(new DamageData(damage, (healthPoint.transform.position - this.transform.position).normalized));
            }
        }        
    }
}