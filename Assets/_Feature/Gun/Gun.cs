using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;

namespace DevilsReturn
{
    public class Gun : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Data"), Required] private GunData data;
        [SerializeField, TitleGroup("Point"), Required] private Transform firePoint;

        private bool isReadyToFire = true;
        private Timer fireCoolTimer;

        public GunData Data => data;
        public float CurrentCoolTime => fireCoolTimer.Current;

        private void Awake()
        {
            fireCoolTimer = new Timer();
        }

        public bool TryFire(DamageData damageData)
        {
            if (data == null) return false;
            if (isReadyToFire == false) return false;

            isReadyToFire = false;
            InstantiateFireFX();
            InstantiateProjectile(damageData);
            PlayFireSound();
            StartCoolTimer();

            return true;
        }

        private void InstantiateFireFX()
        {
            if (data.FireFXPrefab == null) return;

            Instantiate(data.FireFXPrefab, firePoint.position, firePoint.rotation);
        }

        private void InstantiateProjectile(DamageData damageData)
        {
            if (data.ProjectilePrefab == null) return;

            var projectileObj = Instantiate(data.ProjectilePrefab, firePoint.position, firePoint.rotation);
            projectileObj.transform.forward = VectorHelper.GetExceptYFrom(GetDirTowardMouse());
            var projectile = projectileObj.GetComponent<Projectile>();
            projectile.SetDamageData(damageData);
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
