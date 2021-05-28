using LeoESCTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.UnityComponents.EntityTemplates
{
    public class ProjectileTemplate : MonoBehaviour, IEntityTemplate
    {
        [SerializeField]
        private CollisionHandlerComponent _collisionHandler;
        
        public void Create(EcsEntity entity)
        {
            entity.Replace(new ExplosiveTag());
            entity.Replace(new UnityObjectComponent<CollisionHandlerComponent> { Object = _collisionHandler });
        }
    }
}