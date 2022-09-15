using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace DevilsReturn
{
    public class GameClearMenu : BaseMonoBehaviour
    {
        [SerializeField] private UnityEvent onOpen;
        [SerializeField] private ScriptableRelicController relicController;
        [SerializeField] private TextMeshProUGUI deadEnemyCount;
        [SerializeField] private Transform relicFrame;
        [SerializeField] private GameObject relicImagePrefab;

        private void Start()
        {
            Singleton.Game.OnGameClear.AddListener(Open);
        }

        private void Open()
        {
            Singleton.Input.DisableAttackInput();
            Singleton.Input.DisableInteractionInput();
            Singleton.Input.DisableMovementInput();

            Singleton.Camera.FadeIn();
            Singleton.Game.Pause();

            FillRelicFrame();
            SetDeadEnemyCount();

            onOpen?.Invoke();
        }

        private void FillRelicFrame()
        {
            for (int i =0; i < relicController.Get().ControllingRelics.Count; ++i)
            {
                var relicImageFrameObj = Instantiate(relicImagePrefab, relicFrame);
                var relicImageFrame = relicImageFrameObj.GetComponent<RelicImageFrame>();

                relicImageFrame.SetRelic(relicController.Get().ControllingRelics[i]);
            }
        }

        private void SetDeadEnemyCount()
        {
            deadEnemyCount.text = $"Dead Enemy Count : {Singleton.Game.DeadEnemyCount}";
        }
    }
}
