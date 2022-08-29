using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class RelicMetaDataUI : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Data"), Required] private RelicData relicData;
        [SerializeField, TitleGroup("UI")] private TextMeshProUGUI relicName;
        [SerializeField, TitleGroup("UI")] private Image panelImage;
        [SerializeField, TitleGroup("UI")] private TextMeshProUGUI relicDescription;

        private void Start()
        {
            panelImage.color = Singleton.Game.GetTierColor(relicData.Tier);
            relicName.color = Singleton.Game.GetTierColor(relicData.Tier);
            relicName.text = relicData.RelicName.GetString();
            relicDescription.text = relicData.RelicDescription.GetString();
        }
    }
}
