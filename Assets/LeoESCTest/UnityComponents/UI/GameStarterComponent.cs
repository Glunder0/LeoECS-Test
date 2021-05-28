using UnityEngine;
using UnityEngine.EventSystems;

namespace LeoESCTest.UnityComponents.UI
{
    public class GameStarterComponent : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private GameStateComponent _gameState;

        public void OnPointerDown(PointerEventData eventData)
        {
            _gameState.CurrentState = GameState.GamePlay;
        }
    }
}