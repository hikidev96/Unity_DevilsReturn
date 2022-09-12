using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

namespace DevilsReturn
{
    public class Gun : BaseMonoBehaviour, IDrop
    {
        [SerializeField, TitleGroup("Data"), Required] private GunData data;
        [SerializeField, TitleGroup("Point"), Required] private Transform firePoint;
        [SerializeField, TitleGroup("Event"), Required] private UnityEvent _onEquip;
        [SerializeField, TitleGroup("Event"), Required] private UnityEvent _onDrop;

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
                PlayEquipSound();
                _onEquip.Invoke();
            }
        }

        public void SetAttackDamageData(AttackDamageData attackDamageData)
        {
            this.attackDamageData = attackDamageData;
        }
        
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
            projectileObj.transform.forward = VectorHelper.GetExceptYFrom(GetDirTowardMouse());
            var projectile = projectileObj.GetComponent<Projectile>();
            projectile.SetDamage((attackDamageData ? attackDamageData.AttackDamage : 0) + data.Damage);
        }

        private void PlayFireSound()
        {
            if (data.FireSoundData == null) return;

            Singleton.Audio.Play(data.FireSoundData);
        }

        private void PlayEquipSound()
        {
            Singleton.Audio.Play(data.EquipSoundData);
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

        private Vector3 GetDirTowardMouse()
        {
            RaycastHit hit;
            Vector3 result = Vector3.zero;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit, 1000.0f, LayerMask.GetMask("Ground")) == true)
            {
                result = (hit.point - this.transform.position).normalized;
            }

            return result;
        }
    }
}
