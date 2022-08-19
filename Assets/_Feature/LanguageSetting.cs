using UnityEngine;

namespace DevilsReturn
{
    public enum ESupportedLanguage
    {
        English,
        Korean,
    }

    [CreateAssetMenu(menuName = "DevilsReturn/LanguageSetting")]
    public class LanguageSetting : ScriptableObject
    {
        [SerializeField] private ESupportedLanguage currentLanguage;

        public ESupportedLanguage CurrentLanguage => currentLanguage;
    }
}
