using System.Collections;
using UnityEngine;

namespace DevilsReturn
{
    public class MainMenuUI : BaseMonoBehaviour
    {
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
        }
        
        public void Close()
        {
            StartCoroutine(StartCloseLogic());
            isOpen = false;
        }
        
        public void Toggle()
        {
            if (isOpen == true) Close();
            else Open();
        }

        private IEnumerator StartOpenLogic()
        {
            Singleton.Input.DisableAttackInput();
            Singleton.Input.DisableInteractionInput();
            Singleton.Input.DisableMovementInput();
            Singleton.Game.Pause();
            Singleton.Camera.FadeIn();

            yield return new WaitForSecondsRealtime(0.5f);

            canvasFader.FadeIn();
        }

        private IEnumerator StartCloseLogic()
        {
            canvasFader.FadeOut();

            yield return new WaitForSecondsRealtime(0.2f);

            Singleton.Camera.FadeOut();
            Singleton.Game.Resume();
            Singleton.Input.EnableAttackInput();
            Singleton.Input.EnableInteractionInput();
            Singleton.Input.EnableMovementInput();
        }
    }
}