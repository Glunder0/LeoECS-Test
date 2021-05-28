using UnityEngine;
using UnityEngine.EventSystems;

namespace LeoESCTest.UnityComponents
{
    public class ClickPositionHandlerComponent : MonoBehaviour, IPointerDownHandler
    {
        private bool _isClicked;
        private Vector3 _clickPosition;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _isClicked = true;
            _clickPosition = eventData.pointerPressRaycast.worldPosition;
        }

        public bool GetPosition(out Vector3 input)
        {
            if (_isClicked)
            {
                input = _clickPosition;
                _isClicked = false;
                return true;
            }
            else
            {
                input = Vector3.zero;
                return false;
            }
        }
    }
}
