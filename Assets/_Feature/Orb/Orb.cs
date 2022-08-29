using UnityEngine;

namespace DevilsReturn
{
    public class Orb : BaseMonoBehaviour
    {
        [SerializeField] protected ScriptableTransform target;
        [SerializeField] private GameObject comsumeFXPrefab;

        protected bool startMoveToTarget;
        protected bool isActivated;

        private void Update()
        {
            MoveToTarget();
        }

        public virtual void Activate()
        {
            if (isActivated == true) return;

            InstantiateComsumeFX();

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

            this.transform.Translate((GetTargetPosition() - this.transform.position) * Time.deltaTime * 10.0f, Space.World);
            if (Vector3.Distance(this.transform.position, GetTargetPosition()) < 0.5f)
            {                
                Activate();
            }
        }        

        private void InstantiateComsumeFX()
        {
            Instantiate(comsumeFXPrefab, this.transform.position, Quaternion.identity);
        }

        private Vector3 GetTargetPosition()
        {
            return target.Get().position + new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}