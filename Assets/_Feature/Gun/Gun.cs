using UnityEngine;
using Sirenix.OdinInspector;

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
            //projectile.SetDamage((playerDamageData.Get().Damage));
        }

        private void PlayFireSound()
        {
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
