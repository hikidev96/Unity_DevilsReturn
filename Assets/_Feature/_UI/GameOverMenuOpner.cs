using System.Collections;
using UnityEngine;

namespace DevilsReturn
{
    public class GameOverMenuOpner : BaseMonoBehaviour
    {
        private CanvasFader canvasFader;

        private void Awake()
        {
            canvasFader = GetComponent<CanvasFader>();
        }

        public void Open()
        {
            StartCoroutine(StartOpenLogic());
        }

        private IEnumerator StartOpenLogic()
        {
            CameraFadeIn();
            DisableInputs();
            PauseGame();

            yield return new WaitForSecondsRealtime(0.5f);

            CanvasFadeIn();
        }

        private void CanvasFadeIn()
        {
            canvasFader.FadeIn();
        }

        private void CameraFadeIn()
        {
            Singleton.Camera.FadeIn();
        }

        private void PauseGame()
        {
            Singleton.Game.Pause();
        }

        private void DisableInputs()
        {
            Singleton.Input.DisableAttackInput();
            Singleton.Input.DisableInteractionInput();
            Singleton.Input.DisableMovementInput();
            Singleton.Input.DisableUIInput();
        }
    }
}
