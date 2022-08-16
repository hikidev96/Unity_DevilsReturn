using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    public enum ESoundType
    {
        FX,
        BGM,
    }

    [CreateAssetMenu(menuName = "DevilsReturn/SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private ESoundType soundType;
        [SerializeField] private List<AudioClip> clips;

        public ESoundType SoundType => soundType;

        public AudioClip GetClip()
        {
            return clips[Random.Range(0, clips.Count)];
        }
    }
}
