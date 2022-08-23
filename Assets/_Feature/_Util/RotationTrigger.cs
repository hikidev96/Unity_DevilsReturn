using UnityEngine;

namespace DevilsReturn
{
    public class RotationTrigger : BaseMonoBehaviour
    {
        [SerializeField] private Transform targetTrans;
        [SerializeField] private Vector3 targetRotation;

        public void Trigger()
        {
            targetTrans.localRotation = Quaternion.Euler(targetRotation.x, targetRotation.y, targetRotation.z);
        }
    }
}
