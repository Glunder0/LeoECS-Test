using LeoESCTest.Components;
using LeoESCTest.Helpers;
using LeoESCTest.UnityComponents.EntityTemplates;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Creates one entity for each <see cref="GameObject"/> with at least one <see cref="IEntityTemplate"/>,
    /// adds <see cref="GameObjectComponent"/> and executes <see cref="IEntityTemplate.Create"/> of the components accordingly
    ///
    /// Executes on PreInit phase
    /// </summary>
    public class TemplateInitSystem : IEcsPreInitSystem
    {
        private EcsWorld _world;

        public void PreInit()
        {
            foreach (var obj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                InitializeObjectRecursive(obj);
            }
        }

        private void InitializeObjectRecursive(GameObject gameObject)
        {
            TemplateHelper.InitializeTemplates(_world, gameObject);

            foreach (Transform child in gameObject.transform)
            {
                InitializeObjectRecursive(child.gameObject);
            }
        }
    }
}