using UnityEngine;
using DG.Tweening;

namespace DevilsReturn
{
    public class CanvasFader : BaseMonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float fadeInDuration = 0.2f;
        [SerializeField] private float fadeOutDuration = 0.2f;

        public void FadeIn()
        {
            canvasGroup.alpha = 0.0f;
            canvasGroup.DOFade(1.0f, fadeInDuration).SetUpdate(true).SetEase(Ease.Linear);
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void FadeOut()
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.DOFade(0.0f, fadeOutDuration).SetUpdate(true).SetEase(Ease.Linear);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
