using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class HealthPointBarUI : MonoBehaviour
    {
        [SerializeField] private bool getFromScriptableHealthPoint;
        [SerializeField, ShowIf("@getFromScriptableHealthPoint==true")] private ScriptableHealthPoint scriptableHealthPoint;
        [SerializeField, ShowIf("@getFromScriptableHealthPoint==false")] private HealthPoint healthPoint;
        [SerializeField] protected Image fillImage;
        [SerializeField] protected Image whileBackGroundImage;
        [SerializeField] protected TextMeshProUGUI hpTextMesh;
        [SerializeField] private float whileBackGroundSpeed = 0.2f;

        private void Start()
        {
            if (getFromScriptableHealthPoint == true)
            {
                this.healthPoint = scriptableHealthPoint.Get();
            }
        }

        private void Update()
        {
            UpdateFillImage();
            UpdateWhiteBackGround();
            UpdateHpTextMesh();
        }

        protected virtual void UpdateFillImage()
        {
            fillImage.fillAmount = healthPoint.CurrentHP / healthPoint.MaxHp;
        }

        protected virtual void UpdateWhiteBackGround()
        {
            if (whileBackGroundImage == null) return;

            if (whileBackGroundImage.fillAmount > fillImage.fillAmount)
            {
                whileBackGroundImage.fillAmount -= Time.deltaTime * whileBackGroundSpeed;
            }
        }

        protected virtual void UpdateHpTextMesh()
        {
            if (hpTextMesh == null) return;

            hpTextMesh.text = $"{healthPoint.CurrentHP}/{healthPoint.MaxHp}";
        }
    }
}
