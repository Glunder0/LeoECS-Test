using LeoESCTest.Components;
using Leopotam.Ecs;
using UnityEngine.AI;

namespace LeoESCTest.Systems
{
    /// <summary>
    /// Updates destination of <see cref="NavMeshAgent"/> of entities with <see cref="NavAgentTargetSignal"/>
    /// </summary>
    public class NavAgentTargetingSystem : IEcsRunSystem
    {
        private EcsFilter<UnityObjectComponent<NavMeshAgent>, NavAgentTargetSignal> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var agent = ref _filter.Get1(i);
                ref var target = ref _filter.Get2(i);

                agent.Object.destination = target.Target;
            }
        }
    }
}