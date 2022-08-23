using UnityEngine;
using DG.Tweening;

namespace DevilsReturn
{
    public class CanvasFader : BaseMonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;

        public void FadeIn()
        {
            canvasGroup.alpha = 0.0f;
            canvasGroup.DOFade(1.0f, 0.2f).SetUpdate(true);
            canvasGroup.interactable = true;            
        }

        public void FadeOut()
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.DOFade(0.0f, 0.2f).SetUpdate(true);
            canvasGroup.interactable = false;
        }
    }
}
