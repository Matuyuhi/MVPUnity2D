using System;
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
            _rigidbody.AddForce(direction);
        }
    }
}