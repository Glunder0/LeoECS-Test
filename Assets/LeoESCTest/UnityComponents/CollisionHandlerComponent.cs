using UnityEngine;

namespace LeoESCTest.UnityComponents
{
    public class CollisionHandlerComponent : MonoBehaviour
    {
        private int _collisionCount;

        public bool IsColliding => _collisionCount > 0;
        
        private void OnCollisionEnter(Collision other)
        {
            _collisionCount++;
        }

        private void OnCollisionExit(Collision other)
        {
            _collisionCount--;
        }
    }
}