using LeoESCTest.Components;
using LeoESCTest.UnityComponents;
using LeoESCTest.UnityComponents.EntityTemplates;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.Helpers
{
    public static class TemplateHelper
    {
        public static void InitializeTemplates(EcsWorld world, GameObject gameObject)
        {
            var templates = gameObject.GetComponents<IEntityTemplate>();

            if (templates.Length > 0)
            {
                var entity = world.NewEntity();
                entity.Replace(new GameObjectComponent {GameObject = gameObject});
                foreach (var template in templates)
                {
                    template.Create(entity);
                    Object.Destroy(template as MonoBehaviour);
                }

                gameObject.AddComponent<EntityComponent>().Entity = entity;
            }
        }
    }
}