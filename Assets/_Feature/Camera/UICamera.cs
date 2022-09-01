using UnityEngine;

namespace DevilsReturn
{
    public class UICamera : BaseMonoBehaviour
    {
        [SerializeField] private Camera MainCamera;

        private Camera selfCamera;

        private void Awake()
        {
            selfCamera = GetComponent<Camera>();    
        }

        private void Update()
        {
            if (MainCamera == null) return;

            selfCamera.fieldOfView = MainCamera.fieldOfView;
        }
    }
}
