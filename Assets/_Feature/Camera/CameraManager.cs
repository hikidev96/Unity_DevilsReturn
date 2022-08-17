using UnityEngine;

namespace DevilsReturn
{
    public class CameraManager : BaseMonoBehaviour
    {
        private CameraShaker cameraShaker;

        private void Awake()
        {
            cameraShaker = FindObjectOfType<CameraShaker>();
        }

        public void Shake(float power = 2)
        {
            if (cameraShaker == null) return;

            cameraShaker.Shake(power);
        }
    }
}