using LeoESCTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.UnityComponents.EntityTemplates
{
    public class SpawnerTemplate : MonoBehaviour, IEntityTemplate
    {
        public void Create(EcsEntity entity)
        {
            entity.Replace(new SpawnerTag());
        }
    }
}