using UnityEngine;
using System.Threading.Tasks;

namespace DevilsReturn
{
    [System.Serializable]
    public class GuardiansCircletRelicBehaviour : RelicBehaviour
    {
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private GameObject missileFireFXPrefab;

        private float damage = 15.0f;
        private Transform target;

        public override void Activate()
        {
            base.Activate();

            StartFireMissile();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();
        }

        private async void StartFireMissile()
        {
            while (true)
            {
                await Task.Delay(5000);

                if (mainObj == null)
                {
                    break;
                }

                target = FindTarget();

                if (target == null) continue;

                for (int i = 0; i < stack; ++i)
                {
                    await Task.Delay(200);

                    if (mainObj == null) return;

                    var missileObj = GameObject.Instantiate(missilePrefab, mainObj.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    var missileFirFXObj = GameObject.Instantiate(missileFireFXPrefab, mainObj.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    var projectile = missileObj.GetComponent<HomingProjectile>();
                    missileObj.transform.forward = new Vector3(Random.Range(-1.0f, 1.0f), 1.0f, Random.Range(-1.0f, 1.0f));
                    missileFirFXObj.transform.forward = missileObj.transform.forward;
                    projectile.SetTargetToHoming(target);
                    projectile.SetDamage(damage);
                }
            }
        }

        private Transform FindTarget()
        {
            var targets = Physics.OverlapSphere(mainObj.transform.position, 30.0f, 1 << LayerMask.NameToLayer("Enemy"));

            if (targets.Length == 0)
            {
                return null;
            }
            else
            {
                return targets[0].transform;
            }
        }
    }
}