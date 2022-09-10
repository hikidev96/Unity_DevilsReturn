using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class LevelBarUI : BaseMonoBehaviour
    {
        [SerializeField] private bool getFromScriptableLevel;
        [SerializeField, ShowIf("@getFromScriptableLevel==true")] private ScriptableLevelController scriptableLevel;
        [SerializeField, ShowIf("@getFromScriptableLevel==false")] private LevelController level;
        [SerializeField] protected Image fillImage;
        [SerializeField] protected Image whileBackGroundImage;
        [SerializeField] protected TextMeshProUGUI levelTextMesh;
        [SerializeField] private float fillSpeed = 0.2f;

        private void Start()
        {
            if (getFromScriptableLevel == true)
            {
                this.level = scriptableLevel.Get();
            }
        }

        private void Update()
        {
            UpdateFillImage();
            UpdateWhiteBackGround();
            UpdateLevelTextMesh();
        }

        protected virtual void UpdateFillImage()
        {
            if (fillImage.fillAmount < whileBackGroundImage.fillAmount)
            {
                fillImage.fillAmount += Time.deltaTime * fillSpeed;
            }            
            else
            {
                fillImage.fillAmount = whileBackGroundImage.fillAmount;
            }
        }

        protected virtual void UpdateWhiteBackGround()
        {
            whileBackGroundImage.fillAmount = level.CurrentExp / level.NeededExp;
        }

        protected virtual void UpdateLevelTextMesh()
        {
            if (levelTextMesh == null) return;

            levelTextMesh.text = $"LV.{level.CurrentLevel} {level.CurrentExp:0.}/{level.NeededExp:0.}";
        }
    }
}
