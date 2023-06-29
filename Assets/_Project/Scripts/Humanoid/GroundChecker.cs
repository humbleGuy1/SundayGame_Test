using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class GroundChecker
    {
        private Ray _ray;

        public bool CheckFor(GameObject gameObject)
        {
            _ray = new Ray(gameObject.transform.position, gameObject.transform.up * -1);

            if (Physics.Raycast(_ray, Constants.MinDistanceToGround))
                return true;

            return false;
        }
    }
}

