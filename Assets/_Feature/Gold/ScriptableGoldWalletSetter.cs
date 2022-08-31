using UnityEngine;

namespace DevilsReturn
{
    public class ScriptableGoldWalletSetter : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableGoldWallet scriptableGoldWallet;

        private void Awake()
        {
            scriptableGoldWallet.Set(this.GetComponent<GoldWallet>());
        }
    }
}
