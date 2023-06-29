using System;
using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int SpeedHash = Animator.StringToHash("Speed");
        private readonly int JumpHash = Animator.StringToHash("Jump");

        public event Action<int> StepDone;

        public void PlayJump() => _animator.SetTrigger(JumpHash);

        public void PlayMove(float speed) =>
            _animator.SetFloat(SpeedHash, speed);

        //Animation Event
        public void FootStepEvent(int footNumber) => 
            StepDone?.Invoke(footNumber);
    }
}

