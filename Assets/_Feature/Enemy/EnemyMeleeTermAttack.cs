using UnityEngine;

namespace DevilsReturn
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMeleeTermAttack : EnemyAttack
    {
        public void Attack()
        {
            StartCoroutine(StartCoolTime());
        }

        private void OnTriggerEnter(Collider other)
        {
            var healthPoint = other.GetComponent<HealthPoint>();

            if (healthPoint != null && healthPoint.Faction == EFaction.Player)
            {
                healthPoint.Damage(new DamageData(baseDamage, this.transform.forward));
            }
        }
    }
}