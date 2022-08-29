using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class Level : BaseMonoBehaviour
    {
        [SerializeField] private UnityEvent _onLevelUp;

        private int currentLevel = 1;
        private float currentExp = 0.0f;
        private float neededExp = 100.0f;

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

        [Button]
        public void AddExp(float exp)
        {
            currentExp += exp;

            if (currentExp >= neededExp)
            {
                LevelUp();
                currentExp = 0.0f;
                neededExp *= 1.2f;
            }
        }

        private void LevelUp()
        {
            currentLevel += 1;

            _onLevelUp?.Invoke();
        }
    }
}