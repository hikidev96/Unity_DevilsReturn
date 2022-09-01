using UnityEngine;
using System.Threading.Tasks;

namespace DevilsReturn
{
    [System.Serializable]
    public class GuardiansCircletRelicBehaviour : RelicBehaviour
    {
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private GameObject missileFireFXPrefab;

        private float missileDamage = 15.0f;
        private Transform targetToHoming;

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
                if (mainObj == null) break;

                for (int i = 0; i < stack; ++i)
                {
                    await Task.Delay(200);

                    if (mainObj == null) break;

                    targetToHoming = FindTargetToHoming();                    
                    if (targetToHoming == null) break;

                    var missileObj = GameObject.Instantiate(missilePrefab, mainObj.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    var missileFirFXObj = GameObject.Instantiate(missileFireFXPrefab, mainObj.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    var projectile = missileObj.GetComponent<HomingProjectile>();
                    missileObj.transform.forward = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), 1.0f, UnityEngine.Random.Range(-1.0f, 1.0f));
                    missileFirFXObj.transform.forward = missileObj.transform.forward;
                    projectile.SetTargetToHoming(targetToHoming);
                    projectile.SetDamage(missileDamage);
                }
            }
        }

        private Transform FindTargetToHoming()
        {
            var candidatesForTarget = Physics.OverlapSphere(mainObj.transform.position, 30.0f, 1 << LayerMask.NameToLayer("Enemy"));            

            if (candidatesForTarget.Length == 0)
            {
                return null;
            }
            else
            {
                return GetNearestEnemy(candidatesForTarget).transform;
            }
        }

        private Collider GetNearestEnemy(Collider[] candidates)
        {
            var result = candidates[0];

            for (int i = 1; i < candidates.Length; ++i)
            {
                if (Vector3.Distance(mainObj.transform.position, candidates[i].transform.position) <
                    Vector3.Distance(mainObj.transform.position, result.transform.position))
                {
                    result = candidates[i];
                }
            }

            return result;
        }
    }
}