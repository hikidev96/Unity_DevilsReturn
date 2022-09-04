using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace DevilsReturn
{
    public class CameraFader : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private Image fadeImage;
        [SerializeField, TitleGroup("Detail")] private bool onStartFadeOut = true;
        [SerializeField, TitleGroup("Event")] private UnityEvent onFadeInOver;
        [SerializeField, TitleGroup("Event")] private UnityEvent onFadeOutOver;

        private Material fadeMaterial;

        private void Awake()
        {
            fadeMaterial = fadeImage.material;

            if (onFadeInOver == null) onFadeInOver = new UnityEvent();
            if (onFadeOutOver == null) onFadeOutOver = new UnityEvent();
        }

        private void Start()
        {
            if (onStartFadeOut == true)
            {
                StartFadeOut();
            }
        }

        private void OnDisable()
        {
            fadeMaterial.SetFloat("_Progress", 1.0f);
        }

        private void OnDestroy()
        {
            onFadeInOver.RemoveAllListeners();
            onFadeOutOver.RemoveAllListeners();
        }

        public void StartFadeInWithoutReturn()
        {
            StartFadeIn();
        }

        public void StartFadeOutWithoutReturn()
        {
            StartFadeOut();
        }

        public Tweener StartFadeIn()
        {
            fadeMaterial.SetFloat("_Progress", 1.0f);
            var tweener = DOTween.To(() => fadeMaterial.GetFloat("_Progress"), (x) => fadeMaterial.SetFloat("_Progress", x), 0.0f, 0.5f);
            tweener.SetUpdate(true);
            tweener.SetEase(Ease.Linear);
            tweener.onComplete += () => onFadeInOver?.Invoke();
            return tweener;
        }

        public Tweener StartFadeOut()
        {
            fadeMaterial.SetFloat("_Progress", 0.0f);
            var tweener = DOTween.To(() => fadeMaterial.GetFloat("_Progress"), (x) => fadeMaterial.SetFloat("_Progress", x), 1.0f, 0.5f);
            //tweener.SetUpdate(true);
            tweener.SetEase(Ease.Linear);
            tweener.onComplete += () => onFadeOutOver?.Invoke();
            return tweener;
        }
    }
}