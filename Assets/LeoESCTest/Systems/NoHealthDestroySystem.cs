using LeoESCTest.Components;
using Leopotam.Ecs;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Marks entities with <see cref="HealthComponent.Health"/> less or equal to zero with <see cref="DestroyTag"/>
    /// </summary>
    public class NoHealthDestroySystem : IEcsRunSystem
    {
        private EcsFilter<HealthComponent>.Exclude<DestroyTag> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var health = ref _filter.Get1(i);

                if (health.Health <= 0)
                {
                    _filter.GetEntity(i).Get<DestroyTag>();
                }
            }
        }
    }
}