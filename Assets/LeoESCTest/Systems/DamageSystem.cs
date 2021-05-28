using JetBrains.Annotations;
using LeoESCTest.Components;
using Leopotam.Ecs;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Damages <see cref="HealthComponent.Health"/> by <see cref="ReceiveDamageSignal.Damage"/> value
    /// </summary>
    public class DamageSystem : IEcsRunSystem
    {
        [UsedImplicitly]
        private EcsFilter<HealthComponent, ReceiveDamageSignal> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var health = ref _filter.Get1(i);
                ref var damage = ref _filter.Get2(i);

                health.Health -= damage.Damage;
            }
        }
    }
}