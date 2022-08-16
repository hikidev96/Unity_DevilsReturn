using UnityEngine;

namespace DevilsReturn
{
    //[RequireComponent(typeof(GameObjectLifeTimer), typeof(Rigidbody))]  
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected GameObject hitFXPrefab;
        [SerializeField] protected SoundData hitSoundData;
        [SerializeField] protected float speed = 5.0f;
        [SerializeField] protected float lifeTime = 5.0f;

        protected float damage;
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

        public virtual void SetDamage(float damage)
        {
            this.damage = damage;
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

        //protected virtual void Hit(HitBox hitBox)
        //{
        //    hitBox.Hit(new HitData(GetDamageData()));
        //    DestrySelf();
        //}

        //protected virtual DamageData GetDamageData()
        //{
        //    var result = new DamageData(damage);

        //    return result;
        //}

        private void OnTriggerEnter(Collider other)
        {
            //if (other.gameObject.CompareTag("EnemyHitBox"))
            //{
            //    //Hit(other.gameObject.GetComponent<HitBox>());
            //}
        }
    }
}
