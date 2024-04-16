using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input
{
    public class InputActionAccessor: MonoBehaviour
    {
        [SerializeField] private InputActionAsset _inputActionAsset;

        public InputActionEvent CreateAction(Guid actionName)
        {
            var action = _inputActionAsset.FindAction(actionName);
            if (action == null)
            {
                Debug.LogError($"Action '{actionName}' not found.");
                return null;
            }
            var actionEvent = new InputActionEvent(action);
            action.Enable();

            return actionEvent;
        }

        private void Awake()
        {
            Debug.Log("InputActionManager Start");
            _inputActionAsset.Enable();
        }

        private void OnDestroy()
        {
            Debug.Log("InputActionManager Dispose");
            _inputActionAsset.Disable();
        }
    }
}