using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input
{
    public class InputActionManager : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;

        private Dictionary<string, InputAction> _actions = new Dictionary<string, InputAction>();

        private void Awake()
        {
            inputActionAsset.Enable();
        }

        private void OnDestroy()
        {
            foreach (var action in _actions.Values)
            {
                action.Disable();
                action.Dispose();
            }
        }

        public InputAction CreateAction(string actionName, Action<InputAction.CallbackContext> callback)
        {
            if (!_actions.TryGetValue(actionName, out var action))
            {
                action = inputActionAsset.FindAction(actionName);
                if (action == null)
                {
                    Debug.LogError($"Action '{actionName}' not found.");
                    return null;
                }
                _actions.Add(actionName, action);
            }

            action.performed += callback;
            action.Enable();

            return action;
        }

        public void RemoveCallback(string actionName, Action<InputAction.CallbackContext> callback)
        {
            if (_actions.TryGetValue(actionName, out var action))
            {
                action.performed -= callback;
            }
        }
    }
}