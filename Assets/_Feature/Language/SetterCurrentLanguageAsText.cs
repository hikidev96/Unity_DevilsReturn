using UnityEngine;
using TMPro;

namespace DevilsReturn
{
    public class SetterCurrentLanguageAsText : BaseMonoBehaviour
    {
        [SerializeField] private LanguageSetting languageSetting;

        private TextMeshProUGUI textMesh;

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>(); 
        }

        private void Update()
        {
            textMesh.text = languageSetting.CurrentLanguage.ToString();
        }
    }
}
