using UnityEngine;

namespace Feature.Models
{
    public class PlayerModel
    {
        public ushort Health { get; private set; }
        
        public float Speed { get; private set; } = 1.0f;
        
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