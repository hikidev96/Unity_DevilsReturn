using UnityEngine;
using UnityEngine.SceneManagement;

namespace DevilsReturn
{
    public class CameraManager : BaseMonoBehaviour
    {
        private CameraShaker cameraShaker;
        private CameraFader cameraFader;

        private void Awake()
        {
            SceneManager.sceneLoaded += (x, y) => FindNeededComponentsRetatedCamera();
        }

        private void FindNeededComponentsRetatedCamera()
        {
            cameraShaker = FindObjectOfType<CameraShaker>();
            cameraFader = FindObjectOfType<CameraFader>();
        }

        public void Shake(float power = 2)
        {
            if (cameraShaker == null) return;

            cameraShaker.Shake(power);
        }

        public void FadeIn()
        {
            cameraFader.StartFadeIn();
        }

        public void FadeOut()
        {
            cameraFader.StartFadeOut();
        }
    }
}