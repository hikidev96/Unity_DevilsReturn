using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DevilsReturn
{
    public class RelicImageFrame : BaseMonoBehaviour
    {
        [SerializeField] private Image relicImage;
        [SerializeField] private TextMeshProUGUI relicStack;

        public void SetRelic(Relic relic)
        {
            relicImage.sprite = relic.RelicData.RelicImage;
            relicStack.text = $"x{relic.Behaviour.Stack}";
        }
    }
}
