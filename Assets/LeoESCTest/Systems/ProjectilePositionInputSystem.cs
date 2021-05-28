using LeoESCTest.Components;
using LeoESCTest.UnityComponents;
using Leopotam.Ecs;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Creates <see cref="ProjectileSpawnSignal"/> at locations of clicks
    /// </summary>
    public class ProjectilePositionInputSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<UnityObjectComponent<ClickPositionHandlerComponent>> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var handler = ref _filter.Get1(i);

                if (handler.Object.GetPosition(out var pos))
                {
                    _world.NewEntity().Replace(new ProjectileSpawnSignal {SpawnPosition = pos});
                }
            }
        }
    }
}