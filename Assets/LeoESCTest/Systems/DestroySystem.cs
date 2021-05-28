using LeoESCTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Destroys entities tagged with <see cref="DestroyTag"/>
    /// Also destroys paired <see cref="GameObject"/> if it is present
    /// </summary>
    public class DestroySystem : IEcsRunSystem
    {
        private EcsFilter<DestroyTag, GameObjectComponent> _gameObjectFilter;
        private EcsFilter<DestroyTag> _tagFilter;
        
        public void Run()
        {
            // Destroy attached GameObject
            foreach (var i in _gameObjectFilter)
            {
                Object.Destroy(_gameObjectFilter.Get2(i).GameObject);
            }

            // Destroy entities itself
            foreach (var i in _tagFilter)
            {
                _tagFilter.GetEntity(i).Destroy();
            }
        }
    }
}