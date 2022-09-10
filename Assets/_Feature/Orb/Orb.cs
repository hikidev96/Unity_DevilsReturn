using UnityEngine;

namespace DevilsReturn
{
    public class Orb : BaseMonoBehaviour
    {
        [SerializeField] protected ScriptableTransform target;
        [SerializeField] private GameObject activationFXPrefab;

        protected bool startMoveToTarget;
        protected bool isActivated;

        private void Update()
        {
            //MoveToTarget();
        }

        public virtual void Activate()
        {
            if (isActivated == true) return;

            InstantiateActivationFX();

            isActivated = true;
        }

        public void StartMoveingToTarget()
        {
            startMoveToTarget = true;
        }

        protected void DestroySelf()
        {
            Destroy(this.gameObject);
        }

        private void MoveToTarget()
        {
            if (startMoveToTarget == false) return;

            this.transform.Translate((GetTargetPosition() - this.transform.position) * Time.deltaTime * 20.0f, Space.World);
            if (Vector3.Distance(this.transform.position, GetTargetPosition()) < 0.2f)
            {                
                Activate();
            }
        }        

        private void InstantiateActivationFX()
        {
            Instantiate(activationFXPrefab, this.transform.position, Quaternion.identity);
        }

        private Vector3 GetTargetPosition()
        {
            return target.Get().position + new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}