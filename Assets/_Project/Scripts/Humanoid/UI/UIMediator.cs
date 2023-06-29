using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class UIMediator : MonoBehaviour
    {
        [SerializeField] private PlayerJump _playerJump;

        public void PlayerJump() => _playerJump.TryJump();

        public void PlayerShoot()
        {
            print("shoot");
        }
    }
}


