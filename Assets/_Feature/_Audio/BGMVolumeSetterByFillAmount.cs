using UnityEngine;
using UnityEngine.UI;

namespace DevilsReturn
{
    public class BGMVolumeSetterByFillAmount : BaseMonoBehaviour
    {
        [SerializeField] private AudioSetting audioSetting;

        private Image fillImage;

        private void Awake()
        {
            fillImage = GetComponent<Image>();  
        }

        private void Start()
        {
            fillImage.fillAmount = audioSetting.BGMVolume;
        }

        private void Update()
        {
            audioSetting.SetBGMVolume(fillImage.fillAmount);
        }
    }
}
