using LeoESCTest.Components;
using LeoESCTest.Settings;
using LeoESCTest.UnityComponents;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace LeoESCTest.Systems
{
    public class ClockSystem : IEcsRunSystem
    {
        private GameStateComponent _gameState;
        private GameSettings _settings;
        private EcsFilter<UnityObjectComponent<TMP_Text>, ClockTag> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var text = ref _filter.Get1(i);
                
                text.Object.text = (_settings.TimeoutTime - (Time.time - _gameState.StartTime)).ToString("N0");
            }
        }
    }
}