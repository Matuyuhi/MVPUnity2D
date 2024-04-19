using Core.Utilities;
using UnityEngine;

namespace Feature.Views
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView: MonoBehaviour
    {
        Rigidbody2D _rigidbody;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();   
        }
        
        
        public void Move(Vector2 direction)
        {
            DebugEx.LogDetailed(direction);
            _rigidbody.AddForce(direction, ForceMode2D.Force);
        }
        
        public void SetPosition(Vector2 position)
        {
            _rigidbody.position = position;
        }
    }
}