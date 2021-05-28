using System.Linq;
using LeoESCTest.Components;
using LeoESCTest.Settings;
using LeoESCTest.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.Systems
{
    public class ContactExplosionSystem : IEcsRunSystem
    {
        private ExplosionSettings _settings;
        private EcsFilter<UnityObjectComponent<CollisionHandlerComponent>, GameObjectComponent, ExplosiveTag> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var collisionHandler = ref _filter.Get1(i);

                if (collisionHandler.Object.IsColliding)
                {
                    ref var gameObject = ref _filter.Get2(i);
                    var position = gameObject.GameObject.transform.position;
                    
                    _filter.GetEntity(i).Get<DestroyTag>();

                    // Very slow way to find entities in explosion radius
                    var entities = Object.FindObjectsOfType<EntityComponent>()
                        .Select(component => (entity: component.Entity, distance: Vector3.Magnitude(component.transform.position - position)))
                        .Where(tuple => tuple.distance < _settings.ExplosionRadius && tuple.entity.Has<HealthComponent>());

                    foreach (var (entity, distance) in entities)
                    {
                        var damage = (int)(_settings.ExplosionDamage * (1.0f - Mathf.Pow(distance / _settings.ExplosionRadius, 2)));
                        entity.Replace(new ReceiveDamageSignal {Damage = damage});
                    }
                    
                    Object.Instantiate(_settings.ExplosionEffectPrefab, position, Quaternion.Euler(90.0f, 0.0f, 0.0f));
                }
            }
        }
    }
}