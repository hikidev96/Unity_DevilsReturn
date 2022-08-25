using UnityEngine;

namespace DevilsReturn
{
    public class SoundPlayerOneShot : BaseMonoBehaviour
    {
        [SerializeField] private SoundData soundData;

        private void Start()
        {
            Singleton.Audio.Play(soundData);
        }
    }
}
