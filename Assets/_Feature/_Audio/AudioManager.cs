using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    public class AudioManager : BaseMonoBehaviour
    {
        [SerializeField] private GameObject audioChannelPrefab;
        [SerializeField] private int channelCount = 30;
        [SerializeField] private AudioSetting setting;

        private List<AudioSource> fxChannels = new List<AudioSource>();
        private AudioSource bgmChannel;

        private void Awake()
        {
            SpawnFXChannels();
            SpawnBGMChannels();
        }

        private void Update()
        {            
            bgmChannel.volume = setting.BGMVolume;
        }

        public void Play(SoundData audioData)
        {
            if (audioData == null) return;

            var fxChannel = GetIdleFXChannel();

            if (fxChannel == null) return;

            switch (audioData.SoundType)
            {
                case ESoundType.FX:
                    fxChannel.loop = false;
                    fxChannel.volume = setting.SFXVolume;
                    fxChannel.clip = audioData.GetClip();
                    fxChannel.Play();
                    break;
                case ESoundType.BGM:
                    bgmChannel.loop = true;                    
                    bgmChannel.clip = audioData.GetClip();
                    bgmChannel.Play();
                    break;
            }
        }

        private void SpawnFXChannels()
        {
            for (int i = 0; i < channelCount; ++i)
            {
                fxChannels.Add(Instantiate(audioChannelPrefab, this.transform).GetComponent<AudioSource>());
            }
        }

        private void SpawnBGMChannels()
        {
            bgmChannel = Instantiate(audioChannelPrefab, this.transform).GetComponent<AudioSource>();
        }

        private AudioSource GetIdleFXChannel()
        {
            foreach (AudioSource channel in fxChannels)
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
