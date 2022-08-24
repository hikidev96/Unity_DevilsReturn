using Cinemachine;
using DG.Tweening;

namespace DevilsReturn
{
    public class CameraShaker : BaseMonoBehaviour
    {
        private CinemachineVirtualCamera followCamera;
        private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
        private Tweener shakeTweener;

        private void Awake()
        {
            followCamera = GetComponent<CinemachineVirtualCamera>();    
            cinemachineBasicMultiChannelPerlin = followCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Start()
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0.0f;
        }

        public void Shake(float power = 2.0f)
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = power;

            if (shakeTweener != null)
            {
                shakeTweener.Restart();
            }

            shakeTweener = DOTween.To(() => cinemachineBasicMultiChannelPerlin.m_AmplitudeGain, (x) => cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = x, 0.0f, 0.2f);
        }
    }
}
