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
        public float Damage { get; private set; }
        public Vector3 Dir { get; private set; }

        public DamageData(float damage, Vector3 dir)
        {
            this.Damage = damage;
            this.Dir = dir;
        }
    }

    public class HealthPoint : MonoBehaviour
    {
        [SerializeField, TitleGroup("Base")] private EFaction faction;
        [SerializeField, TitleGroup("Base")] private float maxHP;
        [SerializeField, TitleGroup("Point For UI")] private Transform damageUIInstantiationPoint;
        [SerializeField, TitleGroup("FX")] private GameObject bloodFXPrefab;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onDie = new UnityEvent();
        [SerializeField, TitleGroup("Event")] private UnityEvent _onDamage = new UnityEvent();

        public EFaction Faction => faction;
        public float MaxHp => maxHP;
        public float CurrentHP { get; protected set; }
        public UnityEvent OnDie => _onDie;
        public UnityEvent OnDamage => _onDamage;
        public bool IsDead { get; private set; }

        private void Awake()
        {
            CurrentHP = maxHP;
        }

        public virtual void Damage(DamageData damageData)
        {
            if (IsDead == true)
            {
                return;
            }
            
            CurrentHP -= damageData.Damage;
            InstantiateDamageUI(damageData);
            InstantiateBloodFX(damageData);

            if (CurrentHP <= 0.0f)
            {
                IsDead = true;
                _onDie.Invoke();
            }
            else
            {
                _onDamage.Invoke();
            }
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
    }
}