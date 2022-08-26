using UnityEngine;
using DG.Tweening;

namespace DevilsReturn
{
    public class MaterialAlphaFader : BaseMonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float duration = 0.5f;

        private Tweener tweener;

        public void FadeIn()
        {
            if (tweener != null)
            {
                tweener.Kill();
            }

            _renderer.material.SetFloat("_Opacity", 0.0f);
            tweener = DOTween.To(() => _renderer.material.GetFloat("_Opacity"), (x) => _renderer.material.SetFloat("_Opacity", x), 1.0f, duration);
            tweener.SetEase(Ease.Linear);
        }

        public void FadeOut()
        {
            if (tweener != null)
            {
                tweener.Kill();
            }

            _renderer.material.SetFloat("_Opacity", 1.0f);
            tweener = DOTween.To(() => _renderer.material.GetFloat("_Opacity"), (x) => _renderer.material.SetFloat("_Opacity", x), 0.0f, duration);
            tweener.SetEase(Ease.Linear);
        }
    }
}