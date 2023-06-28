using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class PlayerInput : MonoBehaviour
    {
        public bool IsClicking => Input.GetMouseButtonDown(0);
    }
}

