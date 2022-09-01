using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class Level : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Event")] private UnityEvent _onLevelUp;
        [SerializeField, TitleGroup("Sound")] private SoundData levelUpSoundData;

        private int currentLevel = 1;
        private float currentExp = 0.0f;
        private float neededExp = 30.0f;

        public int CurrentLevel => currentLevel;
        public float CurrentExp => currentExp;    
        public float NeededExp => neededExp;
        public UnityEvent OnLevelUp => _onLevelUp;

        private void Awake()
        {
            if (_onLevelUp == null)
            {
                _onLevelUp = new UnityEvent();
            }
        }

        [Button, TitleGroup("For Test")]
        public void AddExp(float exp)
        {
            currentExp += exp;

            if (currentExp >= neededExp)
            {
                LevelUp();
            }
        }

        [Button, TitleGroup("For Test")]
        private void LevelUp()
        {
            currentLevel += 1;
            currentExp = 0.0f;
            neededExp *= 1.2f;
            PlayLevelUpSound();
            _onLevelUp?.Invoke();
        }

        private void PlayLevelUpSound()
        {
            Singleton.Audio.Play(levelUpSoundData);
        }
    }
}