using UnityEngine;

namespace DevilsReturn
{
    public class RootMotionSyncker : BaseMonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        void OnAnimatorMove()
        {
            Debug.Log(animator.deltaPosition);
            this.transform.position += animator.deltaPosition;
        }
    }
}
