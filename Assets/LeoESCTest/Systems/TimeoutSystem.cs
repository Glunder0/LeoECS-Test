using LeoESCTest.Settings;
using LeoESCTest.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Sets <see cref="GameState"/> to <see cref="GameState.RoundCompleted"/> if elapsed time from the start
    /// of the game exceeds <see cref="GameSettings.TimeoutTime"/>
    /// </summary>
    public class TimeoutSystem : IEcsRunSystem
    {
        private GameStateComponent _gameState;
        private GameSettings _settings;
        
        public void Run()
        {
            if (_gameState.CurrentState == GameState.TTS)
            {
                _gameState.StartTime = Time.time;
            }
            
            if (_gameState.CurrentState != GameState.GamePlay)
            {
                return;
            }
            
            if (Time.time - _gameState.StartTime > _settings.TimeoutTime)
            {
                _gameState.CurrentState = GameState.RoundCompleted;
            }
        }
    }
}