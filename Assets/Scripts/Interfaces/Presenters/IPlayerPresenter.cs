using UnityEngine;

namespace Interfaces.Presenters
{
    public interface IPlayerPresenter
    {
        public void OnMove(Vector2 vector);
        
        public void OnJump();

        public void Start();
    }
}