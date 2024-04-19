using System;
using Core.Input;
using Core.Utilities;
using Feature.Common;
using Feature.Presenters;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Main
{
    /// <summary>
    /// UniRxを使ってUpdateから入力を受け取るクラス
    /// Stateを見て、それぞれのPresenterに通知する
    /// </summary>
    public class GameInputController: IStartable, IDisposable
    {
        private readonly InputActionAccessor _inputActionAccessor;
        private readonly GameState _gameState;
        private readonly PlayerPresenter _playerPresenter;
        
        private InputActionEvent _jumpAction;
        private IDisposable _jumpDisposable;
        
        private InputActionEvent _moveAction;
        private IDisposable _moveDisposable;

        [Inject]
        public GameInputController(
            InputActionAccessor inputActionAccessor,
            GameState gameState,
            PlayerPresenter playerPresenter
        )
        {
            _inputActionAccessor = inputActionAccessor;
            _gameState = gameState;
            _playerPresenter = playerPresenter;
        }
        
        
        
        public void Start()
        {
            DebugEx.LogDetailed("GameInputProvider Start");
            EnableJump();
            EnableMove();
        }

        private void EnableJump()
        {
            _jumpAction = _inputActionAccessor.CreateAction(Game.Jump);
            
            _jumpDisposable = Observable.EveryUpdate()
                .Where(_ => IsJump())
                .Subscribe(_ => DebugEx.LogDetailed("Jump!"));
        }


        private void EnableMove()
        {
            _moveAction = _inputActionAccessor.CreateAction(Game.Move);
            
            _moveDisposable = Observable.EveryUpdate()
                .Where(_ => CanMove())
                .Subscribe(_ =>
                {
                    if (_gameState.GetState == GameState.State.Playing)
                    {
                        _playerPresenter.OnMove(_moveAction.ReadValue<Vector2>());
                    }
                });
        }
        
        private bool IsJump() => _jumpAction.ReadValue<float>() > 0;
        
        private bool CanMove() =>
            _moveAction.ReadValue<Vector2>() != Vector2.zero &&
            _gameState.IsPlaying();

        public void Dispose()
        {
            _jumpAction.Clear();
            _jumpDisposable.Dispose();
            
            _moveAction.Clear();
            _moveDisposable.Dispose();
        }
    }
}