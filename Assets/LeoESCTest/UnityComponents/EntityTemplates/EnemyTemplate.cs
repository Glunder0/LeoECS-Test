using LeoESCTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace LeoESCTest.UnityComponents.EntityTemplates
{
    public class EnemyTemplate : MonoBehaviour, IEntityTemplate
    {
        [SerializeField]
        private int _startingHealth;
        
        public void Create(EcsEntity entity)
        {
            entity.Replace(new NavAgentTargetSignal {Target = new Vector3(0.0f, 0.5f, -20.0f)}); // TODO: Do not use hardcoded position
            entity.Replace(new HealthComponent {Health = _startingHealth});
            entity.Replace(new EnemyTag());
        }
    }
}