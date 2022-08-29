using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace DevilsReturn
{
    public class InputManager : MonoBehaviour,
        InputActions.IMovementActions,
        InputActions.IAttackActions,
        InputActions.IInteractionActions,
        InputActions.IUIActions
    {
        private InputActions inputActions;

        public UnityEvent OnFireKeyPress { get; private set; } = new UnityEvent();
        public UnityEvent OnDashKeyPress { get; private set; } = new UnityEvent();
        public UnityEvent OnInteractKeyPress { get; private set; } = new UnityEvent();
        public UnityEvent OnOpenMainMenuKeyPress { get; private set; } = new UnityEvent();
        public float HorizontalValue { get; private set; }
        public float VerticalValue { get; private set; }
        public Vector3 MovementValue => new Vector3(HorizontalValue, 0.0f, VerticalValue);
        public bool IsFireKeyPress { get; private set; }

        private void Awake()
        {
            inputActions = new InputActions();
            SetCallbacks();
        }

        private void OnEnable()
        {
            EnableAllInput();

            SceneManager.sceneLoaded += EnableAllInputWhenSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= EnableAllInputWhenSceneLoaded;
        }

        public void DisableMovementInput()
        {
            inputActions.Movement.Disable();
        }

        public void DisableAttackInput()
        {
            inputActions.Attack.Disable();
        }

        public void DisableInteractionInput()
        {
            inputActions.Interaction.Disable();
        }

        public void DisableUIInput()
        {
            inputActions.UI.Disable();
        }

        public void EnableMovementInput()
        {
            inputActions.Movement.Enable();
        }

        public void EnableAttackInput()
        {
            inputActions.Attack.Enable();
        }

        public void EnableInteractionInput()
        {
            inputActions.Interaction.Enable();
        }

        public void EnableUIInput()
        {
            inputActions.UI.Enable();
        }

        public void EnableAllInput()
        {
            inputActions.Movement.Enable();
            inputActions.Attack.Enable();
            inputActions.Interaction.Enable();
            inputActions.UI.Enable();
        }

        private void EnableAllInputWhenSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            EnableAllInput();
        }

        private void SetCallbacks()
        {
            inputActions.Movement.SetCallbacks(this);
            inputActions.Attack.SetCallbacks(this);
            inputActions.Interaction.SetCallbacks(this);
            inputActions.UI.SetCallbacks(this);
        }

        void InputActions.IMovementActions.OnHorizontal(InputAction.CallbackContext context)
        {
            HorizontalValue = context.ReadValue<float>();
        }

        void InputActions.IMovementActions.OnVertical(InputAction.CallbackContext context)
        {
            VerticalValue = context.ReadValue<float>();
        }

        void InputActions.IAttackActions.OnFire(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnFireKeyPress.Invoke();
                IsFireKeyPress = true;
            }
            else if (context.canceled)
            {
                IsFireKeyPress = false;
            }
        }

        void InputActions.IMovementActions.OnDash(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnDashKeyPress.Invoke();
            }
        }

        void InputActions.IInteractionActions.OnInteract(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnInteractKeyPress.Invoke();
            }
        }

        void InputActions.IUIActions.OnOpenMainMenu(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnOpenMainMenuKeyPress.Invoke();
            }
        }
    }
}