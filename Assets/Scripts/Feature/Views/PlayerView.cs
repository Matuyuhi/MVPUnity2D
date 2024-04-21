#region

using System;
using Core.Utilities;
using UnityEngine;

#endregion

namespace Feature.Views
{
    /// <summary>
    ///     プレイヤーのView
    ///     具体的な操作はPresenterに任せる(ここでは何もしない)
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody2D rigidBody2d;

        private void Awake()
        {
            rigidBody2d = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnHit?.Invoke(other.collider);
        }

        /// <summary>
        ///     colliderに当たった時のイベント通知
        /// </summary>
        public event Action<Collider2D> OnHit;


        /// <summary>
        ///     指定方向に力を加える
        /// </summary>
        /// <param name="direction">方向</param>
        public void AddForce(Vector2 direction)
        {
            DebugEx.LogDetailed(direction);
            rigidBody2d.AddForce(direction, ForceMode2D.Force);
        }

        /// <summary>
        ///     速度を直接 設定する
        /// </summary>
        /// <param name="velocity"></param>
        public void SetVelocity(Vector2 velocity)
        {
            rigidBody2d.velocity = new(velocity.x, velocity.y + rigidBody2d.velocity.y);
        }

        /// <summary>
        ///     位置を直接 設定する
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position)
        {
            rigidBody2d.position = position;
        }
    }
}