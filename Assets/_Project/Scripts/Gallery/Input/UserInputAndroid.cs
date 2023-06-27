using UnityEngine;

namespace SunGameStudio.Gallery
{
    public class UserInputAndroid : IUserInput
    {
        public bool BackActionActivated => Input.GetKey(KeyCode.Escape);
    }
}


