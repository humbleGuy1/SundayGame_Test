using System;
using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;

        private bool _isAming;

        public void Switch()
        {
            if (_isAming)
                StopAiming();
            else
                StartAming();
        }

        private void StartAming()
        {
            _animator.PlayAiming();
            _isAming = true;
        }

        private void StopAiming()
        {
            _animator.StopAiming();
            _isAming = false;
        }
    }
}

