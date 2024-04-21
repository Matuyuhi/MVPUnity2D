#region

using System;
using Core.Input;
using Core.Utilities;
using Feature.Common;
using Feature.Presenters;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

#endregion

namespace Main
{
    /// <summary>
    ///     UniRxを使ってUpdateから入力を受け取るクラス
    ///     Stateを見て、それぞれのPresenterに通知する
    /// </summary>
    public class GameInputController : IStartable, IDisposable
    {
        private readonly CompositeDisposable disposables = new();
        private readonly GameState gameState;
        private readonly InputActionAccessor inputActionAccessor;
        private readonly PlayerPresenter playerPresenter;

        private InputActionEvent jumpAction;

        private InputActionEvent moveAction;

        [Inject]
        public GameInputController(
            InputActionAccessor inputActionAccessor,
            GameState gameState,
            PlayerPresenter playerPresenter
        )
        {
            this.inputActionAccessor = inputActionAccessor;
            this.gameState = gameState;
            this.playerPresenter = playerPresenter;
        }

        public void Dispose()
        {
            jumpAction.Clear();

            moveAction.Clear();

            disposables.Dispose();
        }


        public void Start()
        {
            DebugEx.LogDetailed("GameInputProvider Start");
            EnableJump();
            EnableMove();
        }

        private void EnableJump()
        {
            jumpAction = inputActionAccessor.CreateAction(Game.Jump);

            Observable.EveryUpdate()
                .Where(_ => IsJump())
                .Subscribe(_ =>
                {
                    if (gameState.GetState == GameState.State.Playing)
                    {
                        playerPresenter.OnJump();
                    }
                })
                .AddTo(disposables);
        }


        private void EnableMove()
        {
            moveAction = inputActionAccessor.CreateAction(Game.Move);

            Observable.EveryUpdate()
                .Where(_ => CanMove())
                .Subscribe(_ =>
                {
                    if (gameState.GetState == GameState.State.Playing)
                    {
                        playerPresenter.OnMove(moveAction.ReadValue<Vector2>());
                    }
                })
                .AddTo(disposables);
        }

        private bool IsJump() => jumpAction.ReadValue<float>() > 0;

        private bool CanMove() => gameState.IsPlaying();
    }
}