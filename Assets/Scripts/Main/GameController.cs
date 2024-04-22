#region

using Feature.Common;
using Feature.Common.Scene;
using Feature.Common.Scene.Generated;
using Feature.Presenters;
using Feature.Repository;
using Interfaces.Presenters;
using Main.Input;
using VContainer;
using VContainer.Unity;

#endregion

namespace Main
{
    /// <summary>
    ///     Game Scene全体を管理するクラス
    /// </summary>
    public class GameController : IStartable
    {
        private readonly GameInputController gameInputController;
        private readonly GameState gameState;
        private readonly RootInstance rootInstance;
        private readonly UserRepository userRepository;
        private readonly IPlayerPresenter playerPresenter;

        [Inject]
        public GameController(
            UserRepository userRepository,
            IPlayerPresenter playerPresenter,
            RootInstance rootInstance,
            GameInputController gameInputController,
            GameState gameState
        )
        {
            this.userRepository = userRepository;
            this.rootInstance = rootInstance;
            this.gameInputController = gameInputController;
            this.gameState = gameState;
            this.playerPresenter = playerPresenter;
        }

        public void Start()
        {
            gameState.Initialize();
            gameInputController.Start();
            userRepository.Load();
            playerPresenter.Start();
            /* ここで開始処理 */
            gameState.Start();
        }
    }
}