#region

using System;
using UnityEngine.InputSystem;

#endregion

namespace Core.Input
{
    public class InputActionEvent
    {
        private readonly InputAction action;

        public InputActionEvent(InputAction action)
        {
            this.action = action;

            this.action.performed += OnPerformed;
            this.action.started += OnStarted;
            this.action.canceled += OnCanceled;
            this.action.Enable();
        }

        public event Action<InputAction.CallbackContext> Started;
        public event Action<InputAction.CallbackContext> Performed;
        public event Action<InputAction.CallbackContext> Canceled;

        private void OnStarted(InputAction.CallbackContext ctx)
        {
            Started?.Invoke(ctx);
        }

        private void OnPerformed(InputAction.CallbackContext ctx)
        {
            Performed?.Invoke(ctx);
        }

        private void OnCanceled(InputAction.CallbackContext ctx)
        {
            Canceled?.Invoke(ctx);
        }

        public TValue ReadValue<TValue>() where TValue : struct => action.ReadValue<TValue>();

        public void Clear()
        {
            action.started -= OnStarted;
            action.performed -= OnPerformed;
            action.canceled -= OnCanceled;

            Started = null;
            Performed = null;
            Canceled = null;
            action.Disable();
        }

        public InputAction GetInputAction() => action;
    }
}