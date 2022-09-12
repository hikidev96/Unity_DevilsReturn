using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class GunController : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private GunData startingGun;
        [SerializeField, TitleGroup("Detail")] private AttackDamageData attackDamageData;
        [SerializeField, TitleGroup("RightHand")] private Transform rightHandEquipementPoint;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onFire;
        //[SerializeField, TitleGroup("Data")] private PlayerGunData playerGunData;
        //[SerializeField, TitleGroup("GlobalEvent")] private GameEvent onPlayerGunFire;

        private Gun equippedGun;

        private void Start()
        {
            EquipStartingGun();
        }

        private void Update()
        {
            if (equippedGun == null) return;

            if (Singleton.Input.IsFireKeyPress == true)
            {
                Fire();
            }

            //playerGunData.Set(this.equppedGun);
        }

        public void EquipGun(Gun gun)
        {
            if (equippedGun != null)
            {
                equippedGun.transform.parent = null;
                equippedGun.SetAttackDamageData(null);
                equippedGun.Drop();
            }

            this.equippedGun = gun;

            gun.transform.parent = rightHandEquipementPoint;
            gun.transform.localPosition = Vector3.zero;
            gun.transform.localRotation = Quaternion.identity;
            gun.SetAttackDamageData(attackDamageData);
        }

        private void Fire()
        {
            if (equippedGun == null) return;

            if (equippedGun.TryFire() == true)
            {
                _onFire.Invoke();
                ShakeCamera();
            }
            else
            {

            }
        }

        private void EquipStartingGun()
        {
            if (startingGun == null) return;

            var gun = Instantiate(startingGun.GunPrefab).GetComponent<Gun>();

            EquipGun(gun);
        }

        private void ShakeCamera()
        {
            Singleton.Camera.Shake();
        }
    }
}
