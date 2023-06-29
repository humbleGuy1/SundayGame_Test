using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class PlayerInput
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        public Vector2 Axis =>
             new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}

