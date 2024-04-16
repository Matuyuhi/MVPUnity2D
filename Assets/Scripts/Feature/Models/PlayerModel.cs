using UnityEngine;

namespace Feature.Models
{
    public class PlayerModel
    {
        public ushort Health { get; private set; }
        
        public Vector3 Position { get; set; } = Vector3.zero;
        
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