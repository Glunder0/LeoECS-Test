using DG.Tweening;
using TMPro;
using UnityEngine;

namespace LeoESCTest.UnityComponents
{
    public class DamageIndicator : MonoBehaviour
    {
        [SerializeField]
        private Transform _textTransform;
        
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private float _lifetime;

        [SerializeField]
        private Vector3 _minOffset, _maxOffset;

        private void Start()
        {
            UpdateRotation();
            StartAnimation();
        }

        private void UpdateRotation()
        {
            var cam = Camera.main;
            if (cam != null)
            {
                transform.rotation = cam.transform.rotation;
            }
        }

        private void StartAnimation()
        {
            var offset = Vector3.Lerp(_minOffset, _maxOffset, Random.value);

            _textTransform.DOLocalMove(offset, _lifetime).SetEase(Ease.Linear);
            _text.DOFade(0.0f, _lifetime).SetEase(Ease.InQuad).OnComplete(() => Destroy(gameObject));
        }

        public void SetValue(int value)
        {
            _text.text = value.ToString();
        }
    }
}