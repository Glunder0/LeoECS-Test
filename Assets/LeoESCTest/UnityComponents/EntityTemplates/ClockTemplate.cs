using LeoESCTest.Components;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace LeoESCTest.UnityComponents.EntityTemplates
{
    public class ClockTemplate : MonoBehaviour, IEntityTemplate
    {
        [SerializeField]
        private TMP_Text _text;
        
        public void Create(EcsEntity entity)
        {
            entity.Replace(new UnityObjectComponent<TMP_Text> {Object = _text});
            entity.Replace(new ClockTag());
        }
    }
}