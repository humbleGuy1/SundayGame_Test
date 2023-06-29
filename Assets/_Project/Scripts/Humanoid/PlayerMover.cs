using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private CharacterController _characterController;

        private PlayerInput _input;

        private void Awake() =>
            _input = new PlayerInput();

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_input.Axis.sqrMagnitude > 0.01f)
            {
                movementVector = new(_input.Axis.x, 0, _input.Axis.y);
                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            _characterController.Move(_speed * Time.deltaTime * movementVector);
        }
    }
}

