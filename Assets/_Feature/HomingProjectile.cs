using UnityEngine;

namespace DevilsReturn
{
    public class HomingProjectile : Projectile
    {
        [SerializeField] private float homingSpeed = 5.0f;

        private Transform target;
        private Vector3 randomPosForNoneTarget;

        protected override void Start()
        {
            base.Start();

            if (target == null)
            {
                randomPosForNoneTarget = this.transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            }
        }

        protected override void Move()
        {
            if (target == null)
            {
                this.transform.forward = Vector3.Lerp(this.transform.forward, (randomPosForNoneTarget - this.transform.position).normalized, Time.deltaTime * homingSpeed);                
            }
            else
            {
                this.transform.forward = Vector3.Lerp(this.transform.forward, ((target.position + new Vector3(0, 1, 0)) - this.transform.position).normalized, Time.deltaTime * homingSpeed);                
            }

            rb.MovePosition(rb.position + this.transform.forward * speed * Time.deltaTime);
        }

        public void SetTargetToHoming(Transform target)
        {            
            this.target = target;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, target ? target.transform.position : randomPosForNoneTarget);
        }
    }
}