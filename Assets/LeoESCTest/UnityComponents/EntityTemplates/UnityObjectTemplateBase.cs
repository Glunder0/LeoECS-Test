using LeoESCTest.Components;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LeoESCTest.UnityComponents.EntityTemplates
{
    public class UnityObjectTemplateBase<T> : MonoBehaviour, IEntityTemplate where T : Object
    {
        [SerializeField]
        private T _object;

        public void Create(EcsEntity entity)
        {
            entity.Replace(new UnityObjectComponent<T> {Object = _object});
        }
    }
}