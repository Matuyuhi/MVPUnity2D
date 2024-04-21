#region

using UnityEngine;
using UnityEngine.InputSystem;

#endregion

namespace Core.Input
{
    [CreateAssetMenu(menuName = "InputActionAssetProfile", fileName = "InputActionAssetProfile")]
    public class InputActionAssetProfile : ScriptableObject
    {
        [SerializeField] private InputActionAsset inputActionAsset;

        public InputActionAsset GetUsingAsset() => inputActionAsset;
    }
}