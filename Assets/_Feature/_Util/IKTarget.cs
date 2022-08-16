using UnityEngine;

namespace SOD
{
    public class IKTarget : MonoBehaviour
    {
        [SerializeField] private AvatarIKGoal _Type;
        [SerializeField, Range(0, 1)] private float _PositionWeight = 1;
        [SerializeField, Range(0, 1)] private float _RotationWeight = 0;

        public void UpdateAnimatorIK(Animator animator)
        {
            animator.SetIKPositionWeight(_Type, _PositionWeight);
            animator.SetIKRotationWeight(_Type, _RotationWeight);

            animator.SetIKPosition(_Type, transform.position);
            animator.SetIKRotation(_Type, transform.rotation);
        }
    }
}