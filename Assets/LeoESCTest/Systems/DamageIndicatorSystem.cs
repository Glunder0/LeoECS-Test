using JetBrains.Annotations;
using LeoESCTest.Components;
using LeoESCTest.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Creates damage indicator when entity damaged with <see cref="ReceiveDamageSignal"/>
    /// </summary>
    public class DamageIndicatorSystem : IEcsRunSystem
    {
        private DamageIndicator _damageIndicator;
        
        [UsedImplicitly]
        private EcsFilter<ReceiveDamageSignal, GameObjectComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damage = ref _filter.Get1(i);
                ref var gameObject = ref _filter.Get2(i);

                var indicator = Object.Instantiate(_damageIndicator, gameObject.GameObject.transform.position, Quaternion.identity);
                indicator.SetValue(damage.Damage);
            }
        }
    }
}