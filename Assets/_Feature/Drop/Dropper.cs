using UnityEngine;

namespace DevilsReturn
{
    public class Dropper : BaseMonoBehaviour
    {
        [SerializeField] private PrefabSet prefabSet;
        [SerializeField] private SoundData dropSoundData;

        public void Drop()
        {
            var prefabToDrop = prefabSet.Get();
            var droppableObj = Instantiate(prefabToDrop, this.transform.position, Quaternion.identity).GetComponent<IDrop>();

            if (droppableObj == null) return;

            droppableObj.Drop();
            PlayDropSound();
        }

        private void PlayDropSound()
        {
            Singleton.Audio.Play(dropSoundData);
        }
    }
}