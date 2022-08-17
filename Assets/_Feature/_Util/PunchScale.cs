using UnityEngine;
using DG.Tweening;

namespace DevilsReturn
{
    public class PunchScale : BaseMonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 init = VectorHelper.FullOf(1.0f);
        [SerializeField] private Vector3 punch = VectorHelper.FullOf(1.5f);
        [SerializeField] private float duration = 0.2f;

        private Tweener tweener;

        public void Play()
        {
            if (tweener != null) tweener.Kill();

            target.localScale = init;
            tweener = target.DOPunchScale(punch, duration);
        }
    }
}
