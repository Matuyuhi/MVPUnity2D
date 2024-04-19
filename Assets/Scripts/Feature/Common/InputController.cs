using Core.Input;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Feature.Common
{
    public class InputController
    {
        private readonly InputActionAccessor _inputActionAccessor;
        private readonly GameState _gameState;
        
        private InputActionEvent _jumpAction;
        private InputActionEvent _moveAction;

        public InputController(
            InputActionAccessor inputActionAccessor,
            GameState gameState
        )
        {
            _inputActionAccessor = inputActionAccessor;
            _gameState = gameState;
        }
        
        public void Start()
        {
            Debug.Log("GameInputProvider Start");
            EnableJump();
            EnableMove();
        }

        private void EnableJump()
        {
            _jumpAction = _inputActionAccessor.CreateAction(Game.Jump);
            
            Observable.EveryUpdate()
                .Where(_ => IsJump())
                .Subscribe(_ => Debug.Log("Jump!"));
        }


        private void EnableMove()
        {
            _moveAction = _inputActionAccessor.CreateAction(Game.Move);
            
            Observable.EveryUpdate()
                .Where(_ => IsMove())
                .Subscribe(_ =>
                {
                    Debug.Log("Move!" + _moveAction.ReadValue<Vector2>());
                });
        }
        
        private bool IsJump() => _jumpAction.ReadValue<float>() > 0;
        
        private bool IsMove() => _moveAction.ReadValue<Vector2>() != Vector2.zero;
       
    }
}