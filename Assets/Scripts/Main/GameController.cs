using Feature.Common;
using Feature.Presenters;
using Feature.Repository;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Main
{
    public class GameController: IStartable
    {
        private readonly UserRepository _userRepository;
        private readonly PlayerPresenter _playerPresenter;
        private readonly RootInstance _rootInstance;
        [Inject]
        public GameController(
            UserRepository userRepository,
            PlayerPresenter playerPresenter,
            RootInstance rootInstance
        )
        {
            _userRepository = userRepository;
            _playerPresenter = playerPresenter;
            _rootInstance = rootInstance;
        }
        public void Start()
        {
            _rootInstance.GameState.Initialize();
        }
    }
}