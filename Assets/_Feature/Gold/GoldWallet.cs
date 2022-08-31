using UnityEngine;

namespace DevilsReturn
{
    public class GoldWallet : BaseMonoBehaviour
    {
        [SerializeField] private int startingGold;

        private int currentGold;
        private const int maxGold = 999999999;

        public int CurrentGold => currentGold;

        private void Start()
        {
            currentGold = startingGold;
        }

        public void AddGold(int amount)
        {
            currentGold += amount;

            if (currentGold >= maxGold)
            {
                currentGold = maxGold;
            }
        }

        public bool TryConsumeGold(int amount)
        {
            if (IsHaveMoreThan(amount) == false) return false;

            currentGold -= amount;

            return true;
        }

        private bool IsHaveMoreThan(int amount)
        {
            if (currentGold >= amount) return true;
            else return false;
        }
    }
}