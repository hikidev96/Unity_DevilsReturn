using UnityEngine;

namespace DevilsReturn
{
    public class GoldOrb : Orb
    {
        [SerializeField] private ScriptableGoldWallet goldWallet;

        private int gold;

        public override void Activate()
        {
            if (isActivated == true) return;

            base.Activate();

            goldWallet.Get().AddGold(gold);
            DestroySelf();
        }

        public void SetGold(int exp)
        {
            this.gold = exp;
        }
    }
}
