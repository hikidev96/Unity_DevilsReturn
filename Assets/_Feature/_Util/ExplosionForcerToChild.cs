using UnityEngine;

namespace DevilsReturn
{
    public class ExplosionForcerToChild : MonoBehaviour
    {
        public float MinForce;
        public float MaxForce;
        public float Radious;

        private void Start()
        {
            Explode();            
        }

        private void Explode()
        {
            foreach (Transform t in this.transform)
            {
                var rb = t.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(Random.Range(MinForce, MaxForce), transform.position, Radious, 0.0f, ForceMode.Impulse);
                }
            }
        }
    }
}