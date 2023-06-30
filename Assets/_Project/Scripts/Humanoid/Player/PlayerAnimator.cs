using System;
using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int SpeedHash = Animator.StringToHash("Speed");
        private readonly int JumpHash = Animator.StringToHash("Jump");
        private readonly int AimHash = Animator.StringToHash("IsAiming");

        public event Action<int> StepDone;

        public void PlayJump() => _animator.SetTrigger(JumpHash);

        public void PlayMove(float speed) =>
            _animator.SetFloat(SpeedHash, speed);

        public void PlayAiming() => 
            _animator.SetBool(AimHash, true);

        public void StopAiming() => 
            _animator.SetBool(AimHash, false);

        //Animation Event
        private void FootStepEvent(int footNumber) => 
            StepDone?.Invoke(footNumber);
    }
}

