using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    public class BGMPlayer : BaseMonoBehaviour
    {
        [SerializeField] private List<SoundData> track;

        private void Start()
        {
            StartCoroutine(StartTrack());
        }

        private IEnumerator StartTrack()
        {
            if (track == null) yield break;
            if (track.Count == 0) yield break;

            var index = 0;

            while (true)
            {
                Singleton.Audio.Play(track[index]);
                yield return new WaitForSeconds(track[index].GetClip().length);

                index++;
                if (index == track.Count) index = 0;
            }            
        }
    }
}
