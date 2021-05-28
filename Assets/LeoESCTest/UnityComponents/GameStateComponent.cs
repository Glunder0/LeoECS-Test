using System;
using UnityEngine;

namespace LeoESCTest.UnityComponents
{
    public class GameStateComponent : MonoBehaviour
    {
        private GameState _currentState;
        
        public event Action<GameState> StateChangedEvent;
        
        public GameState CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                StateChangedEvent?.Invoke(_currentState);
            }
        }

        public float StartTime;

        private void Start()
        {
            StartTime = Time.time;
        }
    }
}