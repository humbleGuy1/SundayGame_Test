using UnityEngine;

namespace SunGameStudio.Gallery
{
    public class InputChecker : MonoBehaviour
    {
        private IUserInput _userInput;

        private void Start()
        {
            if (IsAndroid())
            {
                _userInput = new UserInputAndroid();
            }
            else if (IsIPhone())
            {
                _userInput = new UserInputIphone();
            }
        }

        private void Update()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
                return;

            if (_userInput.BackActionActivated)
            {
                SceneLoader.Instance.LoadGalleryScene();
            }
        }

        private bool IsAndroid() =>
            Application.platform == RuntimePlatform.Android;

        private bool IsIPhone() =>
            Application.platform == RuntimePlatform.IPhonePlayer;
    }
}


