using Feature.Models;
using Feature.Views;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Feature.Presenters
{
    public class PlayerPresenter
    {
        private readonly PlayerView _playerView;
        private readonly PlayerModel _playerModel;
        [Inject]
        public PlayerPresenter(
            PlayerView playerView,
            PlayerModel playerModel
        )
        {
            _playerView = playerView;
            _playerModel = playerModel;
        }
    
        public void OnMove(Vector2 vector)
        {
            _playerView.Move(new Vector2(vector.x, 0f) * Time.deltaTime * 1000f *_playerModel.Speed);
        }

    }
}