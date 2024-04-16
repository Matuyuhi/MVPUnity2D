using System;
using UnityEngine.InputSystem;

namespace Core.Input
{
    public class InputActionEvent
    {
        private readonly InputAction _action;
        public InputActionEvent(InputAction action)
        {
            _action = action;
            
            _action.performed += OnPerformed;
            _action.started += OnStarted;
            _action.canceled += OnCanceled;
            _action.Enable();
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

        public TValue ReadValue<TValue>() where TValue : struct
        {
            return _action.ReadValue<TValue>();
        }

        public void Clear()
        {
            _action.started -= OnStarted;
            _action.performed -= OnPerformed;
            _action.canceled -= OnCanceled;

            Started = null;
            Performed = null;
            Canceled = null;
        }

        public InputAction GetInputAction()
        {
            return _action;
        }
        
    }
}