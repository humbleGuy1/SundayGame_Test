using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class UIMediator : MonoBehaviour
    {
        [SerializeField] private PlayerJump _playerJump;
        [SerializeField] private PlayerAim _playerAim;

        public void PlayerJump() => _playerJump.TryJump();

        public void SwitchAim() => _playerAim.Switch();
    }
}


