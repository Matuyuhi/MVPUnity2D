namespace Feature.Models
{
    /// <summary>
    /// プレイヤーの状態を管理するクラス
    /// </summary>
    public class PlayerModel
    {
        public ushort Health { get; private set; }
        
        public float Speed { get; private set; } = 1.0f;
        
        public float JumpPower { get; private set; } = 1.0f;
        
        public bool StayGround { get; set; } = true;
        
        public int SetHealth(ushort health)
        {
            Health = health;
            return Health;
        }
        
        public void Damage(ushort damage)
        {
            Health -= damage;
        }
    }
}