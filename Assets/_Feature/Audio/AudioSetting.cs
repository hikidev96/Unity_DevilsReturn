using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/AudioSetting")]
    public class AudioSetting : ScriptableObject
    {
        [SerializeField, Range(0, 1.0f)] private float sfxVolume;
        [SerializeField, Range(0, 1.0f)] private float bgmVolume;

        public float SFXVolume => sfxVolume;
        public float BGMVolume => bgmVolume;

        public void SetBGMVolume(float volume)
        {
            volume = Mathf.Clamp(volume, 0.0f, 1.0f);

            bgmVolume = volume;
        }

        public void SetSFXVolume(float volume)
        {
            volume = Mathf.Clamp(volume, 0.0f, 1.0f);

            sfxVolume = volume;
        }
    }
}