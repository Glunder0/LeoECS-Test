using LeoESCTest.Components;
using LeoESCTest.Helpers;
using LeoESCTest.Settings;
using LeoESCTest.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LeoESCTest.Systems
{
    public class SpawnerSystem : IEcsRunSystem, IEcsInitSystem
    {
        private const float MinSpawnDelay = 0.01f;
        
        private EcsWorld _world;
        private SpawnerSettings _spawnerSettings;
        private GameStateComponent _gameState;
        private EcsFilter<SpawnerTag, GameObjectComponent> _filter;

        private float _nextSpawnTime;

        public void Init()
        {
            _nextSpawnTime = Time.time;
        }

        public void Run()
        {
            if (_gameState.CurrentState != GameState.GamePlay)
            {
                _nextSpawnTime = Time.time;
                return;
            }
            
            var count = _filter.GetEntitiesCount();
            if (count == 0)
            {
                _nextSpawnTime = Time.time;
                return;
            }

            while (_nextSpawnTime <= Time.time)
            {
                _nextSpawnTime += Mathf.Max(_spawnerSettings.SpawnDelay + _spawnerSettings.SpawnDelayJitter * Random.Range(-1.0f, 1.0f), MinSpawnDelay);

                var spawnerIndex = Random.Range(0, count);

                ref var gameObject = ref _filter.Get2(spawnerIndex);

                var spawned = Object.Instantiate(_spawnerSettings.SpawnedPrefab, gameObject.GameObject.transform.position, Quaternion.identity);
                TemplateHelper.InitializeTemplates(_world, spawned);
            }
        }
    }
}