using Feature.Models;
using Feature.Views;
using UnityEngine;
using VContainer;
using Core.Utilities;

namespace Feature.Presenters
{
    /// <summary>
    /// 外部からの入力を受け取り、Modelに通知、Viewに反映する
    /// </summary>
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
            _playerView.OnHit += OnHit;
        }
    
        /// <summary>
        /// 移動入力を受け取り、Viewに反映する
        /// </summary>
        /// <param name="vector"></param>
        public void OnMove(Vector2 vector)
        {
            if (_playerModel.StayGround)
            {
                _playerView.SetVelocity(new Vector2(vector.x, 0f) * SysEx.Unity.ToDeltaTime * 8f * _playerModel.Speed);
            }
            else
            {
                _playerView.SetVelocity(new Vector2(vector.x, 0f) * SysEx.Unity.ToDeltaTime * 4f * _playerModel.Speed);
            }
        }

        /// <summary>
        /// Jumpを受け取り、Viewに(固定値)を反映する
        /// </summary>
        public void OnJump()
        {
            if (!_playerModel.StayGround) return;
            _playerView.AddForce(Vector2.up * SysEx.Unity.ToDeltaTime * 340f *_playerModel.JumpPower);
            _playerModel.StayGround = false;
        }
        
        private void OnHit(Collider2D collider)
        {
            if (collider.CompareTag("Ground"))
            {
                DebugEx.LogDetailed("Grounded");
                _playerModel.StayGround = true;
            }
        }

    }
}