using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class CameraFadeTrigger : BaseMonoBehaviour
    {
        [SerializeField] private bool useDelay;
        [SerializeField, ShowIf("@useDelay==true")] private float delay;

        private CameraFader cameraFader;
        private UnityEvent _onFadeInOver;
        private UnityEvent _onFadeOutOver;

        private void Awake()
        {
            cameraFader = FindObjectOfType<CameraFader>();
        }

        public void FadeIn()
        {
            if (useDelay == true)
            {
                StartCoroutine(FadeInCoroutine());
                return;
            }

            var tweener = cameraFader.StartFadeIn();
            tweener.onComplete += () => _onFadeInOver?.Invoke();
        }

        public void FadeOut()
        {
            if (useDelay == true)
            {
                StartCoroutine(FadeOutCoroutine());
                return;
            }

            var tweener = cameraFader.StartFadeIn();
            tweener.onComplete += () => _onFadeOutOver?.Invoke();
        }

        private IEnumerator FadeInCoroutine()
        {
            yield return new WaitForSeconds(delay);

            var tweener = cameraFader.StartFadeIn();
            tweener.onComplete += () => _onFadeInOver?.Invoke();
        }

        private IEnumerator FadeOutCoroutine()
        {
            yield return new WaitForSeconds(delay);

            var tweener = cameraFader.StartFadeIn();
            tweener.onComplete += () => _onFadeOutOver?.Invoke();
        }
    }
}
