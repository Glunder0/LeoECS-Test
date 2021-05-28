using System.Collections.Generic;
using LeoESCTest.Components;
using LeoESCTest.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest
{
    internal sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [SerializeField]
        private List<Object> _injectedObjects;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif

            _systems
                .Add(new FailByEnemySystem())
                .Add(new TimeoutSystem())
                .Add(new ClockSystem())

                .Add(new TemplateInitSystem())
                .Add(new SpawnerSystem())
                .Add(new NavAgentTargetingSystem())
                .Add(new ProjectilePositionInputSystem())
                .Add(new ProjectileSpawnSystem())
                .Add(new ContactExplosionSystem())
                .Add(new DamageSystem())
                .Add(new DamageIndicatorSystem())
                .Add(new NoHealthDestroySystem())
                .Add(new DestroySystem());

            _systems
                .OneFrame<ProjectileSpawnSignal>()
                .OneFrame<ReceiveDamageSignal>()
                .OneFrame<NavAgentTargetSignal>();
                
            foreach (var injectedObject in _injectedObjects)
            {
                _systems.Inject(injectedObject);
            }

            _systems.Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy ()
        {
            if (_systems != null) {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}