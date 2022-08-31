using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class GoldWalletUI : BaseMonoBehaviour
    {
        [SerializeField] private bool useScriptableGoldWallet;
        [SerializeField, ShowIf("@useScriptableGoldWallet==true")] private ScriptableGoldWallet scriptableGoldWallet;
        [SerializeField, ShowIf("@useScriptableGoldWallet==false")] private GoldWallet goldWallet;
        [SerializeField] private TextMeshProUGUI goldAmount;        

        private void Start()
        {
            if (useScriptableGoldWallet == true)
            {
                goldWallet = scriptableGoldWallet.Get();
            }
        }

        private void Update()
        {
            UpdateGoldAmountText();
        }

        private void UpdateGoldAmountText()
        {
            goldAmount.text = goldWallet.CurrentGold.ToString();
        }
    }
}
