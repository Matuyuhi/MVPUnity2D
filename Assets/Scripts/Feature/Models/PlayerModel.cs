#region

using UniRx;
using UnityEngine;
using VContainer;

#endregion

namespace Feature.Models
{
    /// <summary>
    ///     プレイヤーの状態を管理するクラス
    /// </summary>
    public class PlayerModel
    {
        [Inject]
        public PlayerModel()
        {
            this.Health = new ReactiveProperty<ushort>(100);
            this.StayGround = new ReactiveProperty<bool>(true);
            this.IsDead = this.Health.Select(x => x <= 0).ToReadOnlyReactiveProperty();
            this.Position = new ReactiveProperty<Vector2>(Vector2.zero);
        }

        public IReactiveProperty<ushort> Health { get; }

        public ReadOnlyReactiveProperty<bool> IsDead { get; private set; }

        public IReactiveProperty<bool> StayGround { get; }

        public float Speed { get; private set; } = 1.0f;

        public float JumpPower { get; private set; } = 1.0f;
        
        public IReactiveProperty<Vector2> Position { get; private set; }

        public bool SetStayGround(bool stayGround)
        {
            this.StayGround.Value = stayGround;
            return this.StayGround.Value;
        }
        
        public Vector2 SetPosition(Vector2 position)
        {
            this.Position.Value = position;
            return this.Position.Value;
        }

        public int SetHealth(ushort health)
        {
            this.Health.Value = health;
            return this.Health.Value;
        }

        public void Damage(ushort damage)
        {
            this.Health.Value -= damage;
        }
    }
}