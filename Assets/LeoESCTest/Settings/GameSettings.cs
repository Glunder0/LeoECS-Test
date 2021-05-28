using UnityEngine;

namespace LeoESCTest.Settings
{
    [CreateAssetMenu(fileName = "New Game Settings", menuName = "Game Settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        private float _timeoutTime;
        [SerializeField]
        private float _failByEnemyLine;

        public float TimeoutTime => _timeoutTime;
        public float FailByEnemyLine => _failByEnemyLine;
    }
}