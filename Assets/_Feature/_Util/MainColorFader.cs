using UnityEngine;
using DG.Tweening;

namespace DevilsReturn
{
    public class MainColorFader : BaseMonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private Color init;
        [SerializeField] private Color end;

        private Tweener tweener;

        public void Play()
        {
            if (tweener != null)
            {
                tweener.Kill();
            }

            _renderer.material.SetColor("_MainColor", init);
            tweener = DOTween.To(() => _renderer.material.GetColor("_MainColor"), (x) => _renderer.material.SetColor("_MainColor", x), end, duration);
        }
    }
}
