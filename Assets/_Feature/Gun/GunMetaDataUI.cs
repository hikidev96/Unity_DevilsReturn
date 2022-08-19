using UnityEngine;
using TMPro;

namespace DevilsReturn
{
    public class GunMetaDataUI : BaseMonoBehaviour
    {
        [SerializeField] private GunData data;
        [SerializeField] private TextMeshProUGUI gunName;
        [SerializeField] private TextMeshProUGUI damageLable;
        [SerializeField] private TextMeshProUGUI fireRateLabel;

        private void Start()
        {

            gunName.text = data.GunName.GetString();
            gunName.color = Singleton.Game.GetTierColor(data.Tier);
            damageLable.text = $"Damage : {data.Damage}";
            fireRateLabel.text = $"Fire Rate : {data.FireRate}";            
        }        
    }
}