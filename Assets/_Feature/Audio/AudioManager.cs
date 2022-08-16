using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    public class AudioManager : BaseMonoBehaviour
    {
        [SerializeField] private GameObject audioChannelPrefab;
        [SerializeField] private int channelCount = 30;
        [SerializeField] private AudioSetting setting;

        private List<AudioSource> channels = new List<AudioSource>();

        private void Awake()
        {
            SpawnChannels();
        }

        public void Play(SoundData audioData)
        {
            var channel = GetIdleChannel();

            if (channel == null)
            {
                return;
            }

            switch (audioData.SoundType)
            {
                case ESoundType.FX:
                    channel.loop = false;
                    channel.volume = setting.FXVolume;
                    break;
                case ESoundType.BGM:
                    channel.loop = true;
                    channel.volume = setting.BgmVolume;
                    break;
            }

            channel.clip = audioData.GetClip();
            channel.Play();
        }

        private void SpawnChannels()
        {
            for (int i = 0; i < channelCount; ++i)
            {
                channels.Add(Instantiate(audioChannelPrefab, this.transform).GetComponent<AudioSource>());
            }
        }

        private AudioSource GetIdleChannel()
        {
            foreach (AudioSource channel in channels)
            {
                if (channel.isPlaying == false)
                {
                    return channel;
                }
            }

            return null;
        }
    }
}
