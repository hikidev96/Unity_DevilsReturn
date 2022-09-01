using UnityEngine;
using DG.Tweening;

namespace DevilsReturn
{
    public class MaterialSelfLitIntensityFader : BaseMonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private bool rewindWhenOver;
        [SerializeField] private float initValue;
        [SerializeField] private float endValue;
        [SerializeField] private float duration = 0.5f;

        private Tweener tweener;

        public void Play()
        {
            if (tweener != null)
            {
                tweener.Kill();
            }

            _renderer.material.SetFloat("_SelfLitIntensity", initValue);
            tweener = DOTween.To(() => _renderer.material.GetFloat("_SelfLitIntensity"), (x) => _renderer.material.SetFloat("_SelfLitIntensity", x), endValue, duration);
            tweener.onComplete += () =>
            {
                if (rewindWhenOver == true)
                {
                    DOTween.To(() => _renderer.material.GetFloat("_SelfLitIntensity"), (x) => _renderer.material.SetFloat("_SelfLitIntensity", x), initValue, duration);
                }
            };
        }
    }
}
