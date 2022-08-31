using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/ScriptableGoldWallet")]
    public class ScriptableGoldWallet : ScriptableObject
    {
        private GoldWallet goldWallet;

        public GoldWallet Get()
        {
            return goldWallet;
        }

        public void Set(GoldWallet goldWallet)
        {
            this.goldWallet = goldWallet;
        }
    }
}
