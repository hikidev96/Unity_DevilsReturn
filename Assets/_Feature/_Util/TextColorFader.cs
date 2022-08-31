using UnityEngine;
using DG.Tweening;
using TMPro;

namespace DevilsReturn
{
    public class TextColorFader : BaseMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        [SerializeField] private Color initColor;
        [SerializeField] private Color destColor;
        [SerializeField] private float duration;

        public void Fade()
        {
            textMeshPro.color = initColor;
            textMeshPro.DOColor(destColor, duration).onComplete += () => textMeshPro.DOColor(initColor, duration);
        }
    }
}
