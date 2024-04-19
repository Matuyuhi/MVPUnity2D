using Feature.Common;
using Feature.Presenters;
using Feature.Repository;
using VContainer;
using VContainer.Unity;

namespace Main
{
    /// <summary>
    /// Game Scene全体を管理するクラス
    /// </summary>
    public class GameController: IStartable
    {
        private readonly UserRepository _userRepository;
        private readonly RootInstance _rootInstance;
        private readonly GameInputController _gameInputController;
        private readonly GameState _gameState;
        [Inject]
        public GameController(
            UserRepository userRepository,
            PlayerPresenter playerPresenter,
            RootInstance rootInstance,
            GameInputController gameInputController,
            GameState gameState
        )
        {
            _userRepository = userRepository;
            _rootInstance = rootInstance;
            _gameInputController = gameInputController;
            _gameState = gameState;
        }
        public void Start()
        {
            _gameState.Initialize();
            _gameInputController.Start();
            _userRepository.Load();
            /* ここで開始処理 */
            _gameState.Start();
        }
    }
}