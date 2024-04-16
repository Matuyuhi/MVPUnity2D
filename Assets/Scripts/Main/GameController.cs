using Feature.Presenters;
using Feature.Repository;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Main
{
    public class GameController: IStartable
    {
        private readonly UserPreference _userPreference;
        private readonly PlayerPresenter _playerPresenter;
        [Inject]
        public GameController(
            UserPreference userPreference,
            PlayerPresenter playerPresenter
        )
        {
            _userPreference = userPreference;
            _playerPresenter = playerPresenter;
        }
        public void Start()
        {
            Debug.Log(_userPreference);
        }
    }
}