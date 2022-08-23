using UnityEngine;

namespace DevilsReturn
{
    public enum ETier
    {
        Tier1,
        Tier2,
        Tier3,
    }

    public class GameManager : BaseMonoBehaviour
    {
        [SerializeField] private LanguageSetting languageSetting;
        [SerializeField] private Color tier1Color;
        [SerializeField] private Color tier2Color;
        [SerializeField] private Color tier3Color;

        public LanguageSetting LanguageSetting => languageSetting;
        public Color Tier1Color => tier1Color;
        public Color Tier2Color => tier2Color;
        public Color Tier3Color => tier3Color;

        public Color GetTierColor(ETier tier)
        {
            switch (tier)
            {
                case ETier.Tier1:
                    return tier1Color;
                case ETier.Tier2:
                    return tier2Color;
                case ETier.Tier3:
                    return tier3Color;
                default:
                    break;
            }

            return Color.white;
        }

        public void Pause()
        {
            Time.timeScale = 0.0f;
        }

        public void Resume()
        {
            Time.timeScale = 1.0f;
        }
    }
}