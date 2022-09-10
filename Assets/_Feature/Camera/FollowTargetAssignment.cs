using UnityEngine;
using Cinemachine;

namespace DevilsReturn
{
    public class FollowTargetAssignment : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableTransform target;

        private CinemachineVirtualCamera virtualCamera;

        private void Awake()
        {
            virtualCamera = this.GetComponent<CinemachineVirtualCamera>();
        }

        private void Start()
        {
            if (virtualCamera == null || target == null) return;

            virtualCamera.Follow = target.Get();
        }
    }
}
