using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [Space]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private PlayerAnimator _animator;

        private void Update() => TryMove();

        private void TryMove()
        {
            Vector3 movementVector = Vector3.zero;

            if (_input.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = new(_input.Axis.x, 0, _input.Axis.y);
                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            _characterController.Move(_speed * Time.deltaTime * movementVector);
            _animator.PlayMove(_characterController.velocity.magnitude);
        }
    }
}

