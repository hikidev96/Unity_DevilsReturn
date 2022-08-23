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
        }

        private void OnDestroy()
        {
            onFadeInOver.RemoveAllListeners();
            onFadeOutOver.RemoveAllListeners();
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

        [Button]
        public void StartFadeIn()
        {
            fadeMaterial.SetFloat("_Progress", 1.0f);
            DOTween.To(() => fadeMaterial.GetFloat("_Progress"), (x) => fadeMaterial.SetFloat("_Progress", x), 0.0f, 0.5f).SetUpdate(true).SetEase(Ease.Linear)
                .onComplete += () => onFadeInOver?.Invoke();
        }

        [Button]
        public void StartFadeOut()
        {
            fadeMaterial.SetFloat("_Progress", 0.0f);
            DOTween.To(() => fadeMaterial.GetFloat("_Progress"), (x) => fadeMaterial.SetFloat("_Progress", x), 1.0f, 0.5f).SetUpdate(true).SetEase(Ease.Linear)
                .onComplete += () => onFadeOutOver?.Invoke();
        }
    }
}