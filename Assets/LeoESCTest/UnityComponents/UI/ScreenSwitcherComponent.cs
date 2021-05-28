using UnityEngine;

namespace LeoESCTest.UnityComponents.UI
{
    public class ScreenSwitcherComponent : MonoBehaviour
    {
        [SerializeField]
        private GameStateComponent _gameState;
        [SerializeField]
        private GameState _state;

        private void Start()
        {
            _gameState.StateChangedEvent += OnStateChangedEvent;
            gameObject.SetActive(_gameState.CurrentState == _state);
        }

        private void OnStateChangedEvent(GameState state)
        {
            gameObject.SetActive(state == _state);
        }
    }
}