using UnityEngine;

namespace SunGameStudio.Gallery
{
    public partial class UserInputIphone : IUserInput
    {
        private float _startTouchPositionX;
        private float _endTouchPositionX;

        private readonly float _swipeThreshold = 25f;

        public bool BackActionActivated => CheckSwipe();

        private bool CheckSwipe()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _startTouchPositionX = touch.position.x;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _endTouchPositionX = touch.position.x;

                    if (_endTouchPositionX - _startTouchPositionX < -_swipeThreshold)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}


