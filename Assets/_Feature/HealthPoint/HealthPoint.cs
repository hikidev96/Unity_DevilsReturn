using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public enum EFaction
    {
        Player,
        Enemy,
        Neutrality,
    }

    public class DamageData
    {
        public float Damage = 0.0f;
        public Vector3 Dir = Vector3.zero;
        public bool IsCritical = false;

        public DamageData(float damage, Vector3 dir, bool isCritical = false)
        {
            this.Damage = damage;
            this.Dir = dir;
            this.IsCritical = isCritical;
        }

        public DamageData()
        {

        }
    }

    public class HealthPoint : MonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private EFaction faction;
        [SerializeField, TitleGroup("Detail")] private float maxHP;
        [SerializeField, TitleGroup("Detail")] private bool cameraShakeWhenDamage = true;
        [SerializeField, TitleGroup("Point For UI")] private Transform damageUIInstantiationPoint;
        [SerializeField, TitleGroup("FX")] private GameObject bloodFXPrefab;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onDie = new UnityEvent();
        [SerializeField, TitleGroup("Event")] private UnityEvent<DamageData> _onDamage = new UnityEvent<DamageData>();

        public EFaction Faction => faction;
        public float MaxHp => maxHP;
        public float CurrentHP { get; protected set; }
        public UnityEvent OnDie => _onDie;
        public UnityEvent<DamageData> OnDamage => _onDamage;
        public bool IsDead { get; private set; }

        private void Awake()
        {
            CurrentHP = maxHP;
        }

        public virtual void Damage(DamageData damageData)
        {
            if (IsDead == true) return;

            CurrentHP -= damageData.Damage;
            InstantiateDamageUI(damageData);
            InstantiateBloodFX(damageData);

            if (CurrentHP <= 0.0f)
            {
                CurrentHP = 0.0f;
                IsDead = true;
                InvokeOnDieEvent();
            }
            else
            {
                InvokeOnDamageEvent(damageData);
                TryCameraShake();
            }
        }

        public virtual void Restore(float amount)
        {
            if (IsDead == true) return;

            CurrentHP += amount;

            if (CurrentHP > maxHP)
            {
                CurrentHP = maxHP;
            }
        }

        public void AddMaxHp(float amount)
        {
            maxHP += amount;
        }

        private void InstantiateDamageUI(DamageData damageData)
        {
            Singleton.UI.InstantiateDamageUI(damageData, damageUIInstantiationPoint.position);
        }

        private void InstantiateBloodFX(DamageData damageData)
        {
            if (bloodFXPrefab == null) return;

            var bloodFXObj = Instantiate(bloodFXPrefab, this.transform.position, Quaternion.identity);
            bloodFXObj.transform.forward = damageData.Dir;
        }

        private void TryCameraShake()
        {
            if (cameraShakeWhenDamage == true)
            {
                Singleton.Camera.Shake();
            }
        }

        private void InvokeOnDieEvent()
        {
            _onDie.Invoke();
        }

        private void InvokeOnDamageEvent(DamageData damageData)
        {
            _onDamage.Invoke(damageData);
        }
    }
}