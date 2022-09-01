using Cinemachine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class CameraZoomOut : BaseMonoBehaviour
    {
        private CinemachineVirtualCamera followCamera;
        private Tweener zoomOutTweener;

        private void Awake()
        {
            followCamera = GetComponent<CinemachineVirtualCamera>();
        }

        private void Start()
        {

        }

        [Button]
        public void ZoomOut(float endValue, float duration = 0.2f)
        {
            if (zoomOutTweener != null)
            {
                zoomOutTweener.Restart();
            }
            
            zoomOutTweener = DOTween.To(() => followCamera.m_Lens.FieldOfView, (fov) => followCamera.m_Lens.FieldOfView = fov, endValue, duration);
        }
    }
}
