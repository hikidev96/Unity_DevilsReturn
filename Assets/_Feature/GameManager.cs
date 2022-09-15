using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public enum ETier
    {
        Tier1,
        Tier2,
        Tier3,
    }

    public class GameManager : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Game Setting")] private LanguageSetting languageSetting;
        [SerializeField, TitleGroup("Color")] private Color tier1Color;
        [SerializeField, TitleGroup("Color")] private Color tier2Color;
        [SerializeField, TitleGroup("Color")] private Color tier3Color;
        [SerializeField, ReadOnly, TitleGroup("Game Goal")] private float elapsedTime;
        [SerializeField, TitleGroup("Game Goal")] private float goalTime;

        private bool isGameClear;
        private bool isGamePuased;
        private UnityEvent onGameClear;

        public LanguageSetting LanguageSetting => languageSetting;
        public Color Tier1Color => tier1Color;
        public Color Tier2Color => tier2Color;
        public Color Tier3Color => tier3Color;
        public float ElapsedTime => elapsedTime;
        public UnityEvent OnGameClear => onGameClear;
        public bool IsGameClear => isGameClear;
        public bool IsGamePuased => isGamePuased;
        public int DeadEnemyCount;

        private void Awake()
        {
            if (onGameClear == null)
            {
                onGameClear = new UnityEvent();
            }
        }

        private void Start()
        {
            isGameClear = false;
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += ResumeForSceneLoaded;
            SceneManager.sceneLoaded += ResetElaspedTime;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= ResumeForSceneLoaded;
            SceneManager.sceneLoaded -= ResetElaspedTime;
        }

        private void Update()
        {
            UpdateElapsedTime();
        }

        public Color GetTierColor(ETier tier)
        {
            switch (tier)
            {
                case ETier.Tier1:
                    return tier1Color;
                case ETier.Tier2:
                    return tier2Color;
                case ETier.Tier3:
                    return tier3Color;
                default:
                    break;
            }

            return Color.white;
        }

        public void Pause()
        {
            Time.timeScale = 0.0f;
            isGamePuased = true;
        }

        public void Resume()
        {
            Time.timeScale = 1.0f;
            isGamePuased = false;
        }

        private void ResumeForSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            Resume();
        }

        private void ResetElaspedTime(Scene scene, LoadSceneMode loadSceneMode)
        {
            elapsedTime = 0.0f;
        }

        private void UpdateElapsedTime()
        {
            if (isGameClear == true) return;

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= goalTime)
            {
                elapsedTime = goalTime;
                isGameClear = true;
                onGameClear?.Invoke();
            }
        }

        [Button]
        private void KillAllEnemy()
        {
            var healthPoints = FindObjectsOfType<HealthPoint>();

            for (int i= 0; i < healthPoints.Length; ++i)
            {
                if (healthPoints[i].Faction == EFaction.Enemy)
                {
                    healthPoints[i].Damage(new DamageData(999999, Vector3.zero));
                }
            }
        }

        [Button] 
        private void SetElapsedTime(float elapsedTime)
        {
            this.elapsedTime = elapsedTime;
        }
    }
}