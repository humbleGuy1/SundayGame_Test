using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class Coin : MonoBehaviour, IClickable
    {
        [SerializeField] private Rotator _rotator;
        [SerializeField] private ColorChanger _colorChanger;
        [SerializeField] private Shacker _shacker;

        public void OnClick()
        {
            _colorChanger.ChangeColor();
            _shacker.Shake();
        }
    }
}

