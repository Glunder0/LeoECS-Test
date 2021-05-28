using LeoESCTest.Components;
using LeoESCTest.Settings;
using LeoESCTest.UnityComponents;
using Leopotam.Ecs;

namespace LeoESCTest.Systems
{
    public class FailByEnemySystem : IEcsRunSystem
    {
        private GameStateComponent _gameState;
        private GameSettings _settings;
        private EcsFilter<GameObjectComponent, EnemyTag> _filter;

        public void Run()
        {
            if (_gameState.CurrentState != GameState.GamePlay)
            {
                return;
            }
            
            foreach (var i in _filter)
            {
                ref var gameObject = ref _filter.Get1(i);

                if (gameObject.GameObject.transform.position.z < _settings.FailByEnemyLine)
                {
                    _gameState.CurrentState = GameState.RoundFailed;
                }
            }
        }
    }
}