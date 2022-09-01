using UnityEngine;
using UnityEngine.SceneManagement;

namespace DevilsReturn
{
    public class CameraManager : BaseMonoBehaviour
    {
        private CameraShaker cameraShaker;
        private CameraFader cameraFader;
        private CameraZoomOut cameraZoomOut;

        private void Awake()
        {
            SceneManager.sceneLoaded += (x, y) => FindNeededComponentsRetatedCamera();
        }

        private void FindNeededComponentsRetatedCamera()
        {
            cameraShaker = FindObjectOfType<CameraShaker>();
            cameraFader = FindObjectOfType<CameraFader>();
            cameraZoomOut = FindObjectOfType<CameraZoomOut>();
        }

        public void Shake(float power = 4)
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

        public void ZoomOut(float endValue, float duration = 0.2f)
        {
            cameraZoomOut.ZoomOut(endValue, duration);
        }
    }
}