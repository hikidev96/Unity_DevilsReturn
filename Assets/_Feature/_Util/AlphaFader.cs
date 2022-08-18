using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace SOD
{
    public class AlphaFader : MonoBehaviour
    {
        [SerializeField] private bool onStart;
        [SerializeField, ShowIf("@onStart==true")] private float onStartDelay = 3.0f;
        [SerializeField] private float endValue = 0.0f;
        [SerializeField] private float duration = 1.0f;

        private void Start()
        {
            if (onStart == true)
            {
                Invoke("FadeOut", onStartDelay);
            }
        }

        public void FadeOut()
        {
            var mat = this.GetComponent<MeshRenderer>().material;

            DOTween.To(() => mat.GetFloat("_Opacity"), (x) => mat.SetFloat("_Opacity", x), endValue, duration);
        }
    }
}