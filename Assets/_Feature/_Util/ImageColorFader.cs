using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DevilsReturn
{
    public class ImageColorFader : BaseMonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Color initColor;
        [SerializeField] private Color destColor;
        [SerializeField] private float duration;

        public void Fade()
        {
            image.color = initColor;
            image.DOColor(destColor, duration).onComplete += () => image.DOColor(initColor, duration);
        }
    }
}
