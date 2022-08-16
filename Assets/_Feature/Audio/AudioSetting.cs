using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/AudioSetting")]
    public class AudioSetting : ScriptableObject
    {
        [SerializeField, Range(0, 1.0f)] private float fxVolume;
        [SerializeField, Range(0, 1.0f)] private float bgmVolume;

        public float FXVolume => fxVolume;
        public float BgmVolume => bgmVolume;
    }
}
