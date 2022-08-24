using System;
using UnityEngine;

namespace DevilsReturn
{
    public enum ESupportedLanguage
    {
        English = 0,
        Korean = 1,
    }

    [CreateAssetMenu(menuName = "DevilsReturn/LanguageSetting")]
    public class LanguageSetting : ScriptableObject
    {
        [SerializeField] private ESupportedLanguage currentLanguage;

        public ESupportedLanguage CurrentLanguage => currentLanguage;

        public void SetLanguage(ESupportedLanguage targetLanguage)
        {
            currentLanguage = targetLanguage;
        }

        public void SetLanguageByIndex(int index)
        {
            if (index < 0) index = 0;
            if (Enum.GetNames(typeof(ESupportedLanguage)).Length <= index) index = Enum.GetNames(typeof(ESupportedLanguage)).Length - 1;

            currentLanguage = (ESupportedLanguage)index;
        }

        public void SetLanguageByNextIndex()
        {
            SetLanguageByIndex((int)currentLanguage + 1);
        }

        public void SetLanguageByPreviousIndex()
        {
            SetLanguageByIndex((int)currentLanguage - 1);
        }
    }
}