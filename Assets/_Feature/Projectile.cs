using UnityEngine;

namespace DevilsReturn
{
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]  
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected GameObject hitFXPrefab;
        [SerializeField] protected SoundData hitSoundData;
        [SerializeField] protected EFaction factionToDamage = EFaction.Enemy;
        [SerializeField] protected float speed = 5.0f;
        [SerializeField] protected float lifeTime = 5.0f;

        protected DamageData damageData;
        protected Vector3 forwardDir;
        protected Rigidbody rb;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>(); 
        }

        protected virtual void Start()
        {
            forwardDir = this.transform.forward;
            Invoke("DestrySelf", lifeTime);
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        public virtual void SetDamageData(DamageData damageData)
        {
            this.damageData = damageData;
        }

        public virtual void DestrySelf()
        {
            InstantiateHitFXPrefab();
            PlayHitSound();
            Destroy(this.gameObject);
        }

        protected virtual void Move()
        {
            rb.MovePosition(rb.position + forwardDir * speed * Time.deltaTime);
        }        

        private void InstantiateHitFXPrefab()
        {
            if (hitFXPrefab == null)
            {
                return;
            }

            Instantiate(hitFXPrefab, this.transform.position, Quaternion.identity);
        }

        private void PlayHitSound()
        {
            Singleton.Audio.Play(hitSoundData);
        }        

        private void OnTriggerEnter(Collider other)
        {
            var healthPoint = other.GetComponent<HealthPoint>();

            if (healthPoint != null && healthPoint.Faction == factionToDamage)
            {
                damageData.Dir = this.transform.forward;
                healthPoint.Damage(damageData);
                DestrySelf();
            }

            if (other.CompareTag("Ground") == true)
            {
                DestrySelf();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
           var healthPoint = collision.transform.GetComponent<HealthPoint>();

            if (healthPoint != null && healthPoint.Faction == factionToDamage)
            {
                damageData.Dir = this.transform.forward;
                healthPoint.Damage(damageData);
                DestrySelf();
            }

            if (collision.transform.CompareTag("Ground") == true)
            {
                DestrySelf();
            }
        }        
    }
}