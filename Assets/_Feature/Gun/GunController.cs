using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class GunController : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Required"), Required] private Gun equippedGun;
        [SerializeField, TitleGroup("Detail")] private AttackData attackData;
        [SerializeField, TitleGroup("RightHand")] private Transform rightHandEquipementPoint;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onFire;

        private void Update()
        {
            if (equippedGun == null) return;

            if (Singleton.Input.IsFireKeyPress == true)
            {
                Fire();
            }
        }

        private void Fire()
        {
            if (equippedGun == null) return;

            if (equippedGun.TryFire(GetDamageData()) == true)
            {
                _onFire.Invoke();
                ShakeCamera();
            }
            else
            {

            }
        }

        private DamageData GetDamageData()
        {
            var result = new DamageData();

            if (attackData.CriticalChance > Random.Range(0.0f, 100.0f)) // Critical
            {
                result = new DamageData(attackData.Damage * attackData.CriticalDamage, this.transform.forward, true);
            }
            else
            {
                result = new DamageData(attackData.Damage, this.transform.forward);
            }            

            return result;
        }

        private void ShakeCamera()
        {
            Singleton.Camera.Shake();
        }
    }
}