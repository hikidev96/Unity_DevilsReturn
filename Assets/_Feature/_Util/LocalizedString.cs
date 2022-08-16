using UnityEngine;

namespace DevilsReturn
{
    [System.Serializable]
    public class LocalizedString
    {
        [SerializeField, TextArea] private string english;
        [SerializeField, TextArea] private string korean;

        public string GetString()
        {
            //var currentLanguage = ServiceProvider.GameService.LanguageSetting.CurrentLanguage;

            //switch (currentLanguage)
            //{
            //    case ESupportedLanguage.English:
            //        return english;
            //    case ESupportedLanguage.Korean:
            //        return korean;
            //    default:
            //        Debug.LogError("Wrong Case");
            //        break;
            //}

            return null;
        }
    }
}
