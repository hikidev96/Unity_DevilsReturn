using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace DevilsReturn
{
    public class InputManager : MonoBehaviour, InputActions.IMovementActions, InputActions.IAttackActions, InputActions.IInteractionActions
    {
        private InputActions inputActions;

        public UnityEvent OnFireKeyPress { get; private set; } = new UnityEvent();
        public UnityEvent OnDashKeyPress { get; private set; } = new UnityEvent();
        public UnityEvent OnInteractKeyPress { get; private set; } = new UnityEvent();
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

        public void EnableAllInput()
        {
            inputActions.Movement.Enable();
            inputActions.Attack.Enable();
            inputActions.Interaction.Enable();
        }

        private void SetCallbacks()
        {
            inputActions.Movement.SetCallbacks(this);
            inputActions.Attack.SetCallbacks(this);
            inputActions.Interaction.SetCallbacks(this);
        }

        void InputActions.IMovementActions.OnHorizontal(InputAction.CallbackContext context)
        {
            HorizontalValue = context.ReadValue<float>();
        }

        void InputActions.IMovementActions.OnVertical(InputAction.CallbackContext context)
        {
            VerticalValue = context.ReadValue<float>();
        }

        void InputActions.IAttackActions.OnHandFire(InputAction.CallbackContext context)
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
    }
}