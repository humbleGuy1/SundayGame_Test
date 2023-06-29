using DG.Tweening;
using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _range;
        [SerializeField] private float _jumpPower;
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _jumpCurve;
        [Space]
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerAnimator _playerAnimator;

        private GroundChecker _groundChecker;

        private void Awake() =>
            _groundChecker = new GroundChecker();

        public void TryJump()
        {
            if (_groundChecker.CheckFor(gameObject))
            {
                _playerAnimator.PlayJump();

                Vector3 jumpDirection = GetDirection();

                transform.DOJump(jumpDirection * _range, _jumpPower, 0, _duration)
                    .SetRelative(true)
                    .SetEase(_jumpCurve);
            }
        }

        private Vector3 GetDirection() =>
            _playerInput.Axis == Vector2.zero ? Vector3.zero : transform.forward;
    }
}

