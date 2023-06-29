using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;

        private readonly int SpeedHash = Animator.StringToHash("Speed");

        private void Update()
        {
            _animator.SetFloat(SpeedHash, _characterController.velocity.magnitude);
        }
    }
}

