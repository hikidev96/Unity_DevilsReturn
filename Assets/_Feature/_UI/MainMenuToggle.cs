using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DevilsReturn
{
    public class MainMenuToggle : BaseMonoBehaviour
    {
        [SerializeField] private UnityEvent _onOpen;
        [SerializeField] private UnityEvent _onClose;

        private bool isOpen;
        private CanvasFader canvasFader;

        private void Awake()
        {
            canvasFader = GetComponent<CanvasFader>();
        }

        private void Start()
        {
            Singleton.Input.OnOpenMainMenuKeyPress.AddListener(() => Toggle());
        }

        public void Open()
        {
            StartCoroutine(StartOpenLogic());
            isOpen = true;
            _onOpen?.Invoke();
        }

        public void Close()
        {
            StartCoroutine(StartCloseLogic());
            isOpen = false;
            _onClose?.Invoke(); 
        }

        public void Toggle()
        {
            if (isOpen == true) Close();
            else Open();
        }

        private IEnumerator StartOpenLogic()
        {
            CameraFadeIn();
            DisableInputs();
            PauseGame();

            yield return new WaitForSecondsRealtime(0.5f);

            CanvasFadeIn();
        }

        private IEnumerator StartCloseLogic()
        {
            CanvasFadeOut();

            yield return new WaitForSecondsRealtime(0.2f);

            CameraFadeOut();
            EnableInputs();
            ResumeGame();
        }

        private void CanvasFadeIn()
        {
            canvasFader.FadeIn();
        }

        private void CanvasFadeOut()
        {
            canvasFader.FadeOut();
        }

        private void CameraFadeIn()
        {
            Singleton.Camera.FadeIn();
        }

        private void CameraFadeOut()
        {
            Singleton.Camera.FadeOut();
        }

        private void PauseGame()
        {
            Singleton.Game.Pause();
        }

        private void ResumeGame()
        {
            Singleton.Game.Resume();
        }

        private void DisableInputs()
        {
            Singleton.Input.DisableAttackInput();
            Singleton.Input.DisableInteractionInput();
            Singleton.Input.DisableMovementInput();
        }

        private void EnableInputs()
        {
            Singleton.Input.EnableAttackInput();
            Singleton.Input.EnableInteractionInput();
            Singleton.Input.EnableMovementInput();
        }
    }
}