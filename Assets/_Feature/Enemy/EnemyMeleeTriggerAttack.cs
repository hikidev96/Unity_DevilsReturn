using UnityEngine;

namespace DevilsReturn
{
    public class EnemyMeleeTriggerAttack : EnemyAttack
    {
        public void Attack()
        {
            StartCoroutine(StartCoolTime());

            var overraped = Physics.OverlapSphere(this.transform.position + (this.transform.forward * range), 1.0f);

            for (int i = 0; i < overraped.Length; ++i)
            {
                var healthPoint = overraped[i].GetComponent<HealthPoint>();

                if (healthPoint != null && healthPoint.Faction == EFaction.Player)
                {
                    healthPoint.Damage(new DamageData(baseDamage, this.transform.forward));
                }
            }
        }
    }
}
