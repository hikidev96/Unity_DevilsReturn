using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class Gun : BaseMonoBehaviour, IDrop
    {
        [SerializeField, TitleGroup("Data"), Required] private GunData data;
        [SerializeField, TitleGroup("Point"), Required] private Transform firePoint;
        [SerializeField, FoldoutGroup("Event"), Required] private UnityEvent _onEquip;
        [SerializeField, FoldoutGroup("Event"), Required] private UnityEvent _onDrop;

        private bool isReadyToFire = true;
        private Timer fireCoolTimer;
        private AttackDamageData attackDamageData;

        public GunData Data => data;
        public float CurrentCoolTime => fireCoolTimer.Current;

        private void Awake()
        {
            fireCoolTimer = new Timer();
        }

        public bool TryFire()
        {
            if (data == null) return false;
            if (isReadyToFire == false) return false;

            isReadyToFire = false;
            InstantiateFireFX();
            InstantiateProjectile();
            PlayFireSound();
            StartCoolTimer();

            return true;
        }

        public void EquipTo(Interacter interacter)
        {
            var gunController = interacter.GetComponentInChildren<GunController>();

            if (gunController != null)
            {
                gunController.EquipGun(this);
                _onEquip.Invoke();
            }
        }

        public void SetAttackDamageData(AttackDamageData attackDamageData)
        {
            this.attackDamageData = attackDamageData;
        }

        [Button]
        public void Drop()
        {
            _onDrop?.Invoke();
            this.transform.rotation = Quaternion.identity;  
        }

        private void InstantiateFireFX()
        {
            if (data.FireFXPrefab == null) return;

            Instantiate(data.FireFXPrefab, firePoint.position, firePoint.rotation);
        }

        private void InstantiateProjectile()
        {
            if (data.ProjectilePrefab == null) return;

            var projectileObj = Instantiate(data.ProjectilePrefab, firePoint.position, firePoint.rotation);
            projectileObj.transform.forward = new Vector3(firePoint.forward.x, 0.0f, firePoint.forward.z);
            var projectile = projectileObj.GetComponent<Projectile>();
            projectile.SetDamage((attackDamageData ? attackDamageData.AttackDamage : 0) + data.Damage);
        }

        private void PlayFireSound()
        {
            if (data.FireSoundData == null) return;

            Singleton.Audio.Play(data.FireSoundData);
        }

        private void StartCoolTimer()
        {
            fireCoolTimer.StartTimer(data.FireRate, () => isReadyToFire = true);
        }

        private void OnDrawGizmos()
        {
            DrawFirePointOnGizmo();
        }

        private void DrawFirePointOnGizmo()
        {
            if (firePoint == null) return;

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(firePoint.position, 0.1f);
        }
    }
}
