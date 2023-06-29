using UnityEngine;
using DG.Tweening;

namespace SunGameStudio.RoatatingObject
{
    public class PyramidTransfomChanger : MonoBehaviour
    {
        [SerializeField] private float _targetY;
        [SerializeField] private float _moveDuration;
        [SerializeField] private float _scaleChangeDuration;
        [SerializeField] private float _growLimit;
        [SerializeField] private ClickCounter _clickCounter;
        [SerializeField] private ParticleSystem _dust;

        private Vector3 _decreaseScale = new(0.1f, 0.1f, 0.1f);
        private Vector3 _increaseScale = new(0.25f, 0.25f, 0.25f);

        private void OnEnable() =>
            _clickCounter.ValueReached += Move;

        private void OnDisable() =>
            _clickCounter.ValueReached -= IncreaseScale;

        public void Move()
        {
            _dust.Play();

            Tween tween = transform.DOMoveY(_targetY, _moveDuration);
            tween.onComplete += _dust.Stop;

            _clickCounter.ValueReached -= Move;
            _clickCounter.ValueReached += IncreaseScale;
        }

        public void IncreaseScale()
        {
            if (transform.localScale.x >= _growLimit)
            {
                _clickCounter.ValueReached -= IncreaseScale;
                return;
            }

            Vector3 currentScale = transform.localScale;
           
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(currentScale - _decreaseScale, _scaleChangeDuration / 3));
            sequence.Append(transform.DOScale(currentScale + _increaseScale, _scaleChangeDuration));
        }
    }
}


