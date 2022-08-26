using UnityEngine;

namespace DevilsReturn
{
    public class RotationTriggerUsingScriptableTarget : BaseMonoBehaviour
    {
        [SerializeField] private Transform transformToRotate;
        [SerializeField] private ScriptableTransform target;
        [SerializeField] private bool exceptY;

        public void Trigger()
        {
            transformToRotate.forward = VectorHelper.GetDir(transformToRotate.position, target.Get().position, exceptY);
        }
    }
}
