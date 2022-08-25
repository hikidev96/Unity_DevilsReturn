using UnityEngine;
using UnityEngine.UI;

namespace DevilsReturn
{
    public class SFXVolumeSetterByFillAmount : BaseMonoBehaviour
    {
        [SerializeField] private AudioSetting audioSetting;

        private Image fillImage;

        private void Awake()
        {
            fillImage = GetComponent<Image>();  
        }

        private void Start()
        {
            fillImage.fillAmount = audioSetting.SFXVolume;
        }

        private void Update()
        {
            audioSetting.SetSFXVolume(fillImage.fillAmount);
        }
    }
}
