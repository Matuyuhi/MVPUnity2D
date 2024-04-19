using System;
using Core.Utilities;
using UnityEngine;

namespace Feature.Views
{
    /// <summary>
    /// プレイヤーのView
    /// 具体的な操作はPresenterに任せる(ここでは何もしない)
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView: MonoBehaviour
    {
        private Rigidbody2D _rigidBody2d;
        
        /// <summary>
        /// colliderに当たった時のイベント通知
        /// </summary>
        public event Action<Collider2D> OnHit;
        
        private void Awake()
        {
            _rigidBody2d = GetComponent<Rigidbody2D>();   
        }
        
        
        /// <summary>
        /// 指定方向に力を加える
        /// </summary>
        /// <param name="direction">方向</param>
        public void AddForce(Vector2 direction)
        {
            DebugEx.LogDetailed(direction);
            _rigidBody2d.AddForce(direction, ForceMode2D.Force);
        }
        
        /// <summary>
        /// 速度を直接 設定する
        /// </summary>
        /// <param name="velocity"></param>
        public void SetVelocity(Vector2 velocity)
        {
            _rigidBody2d.velocity = new Vector2(velocity.x, velocity.y + _rigidBody2d.velocity.y);
        }
        
        /// <summary>
        /// 位置を直接 設定する
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position)
        {
            _rigidBody2d.position = position;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnHit?.Invoke(other.collider);
        }
    }
}