using LeoESCTest.Components;
using LeoESCTest.Helpers;
using LeoESCTest.Settings;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Spawns projectiles
    /// </summary>
    public class ProjectileSpawnSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private ProjectileSpawnSettings _settings;

        private EcsFilter<ProjectileSpawnSignal> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var spawnSignal = ref _filter.Get1(i);

                var position = new Vector3(spawnSignal.SpawnPosition.x, _settings.SpawnHeight, spawnSignal.SpawnPosition.z);
                var gameObject = Object.Instantiate(_settings.ProjectilePrefab, position, Quaternion.identity);
                TemplateHelper.InitializeTemplates(_world, gameObject);
            }
        }
    }
}