using System;
using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class Coin : MonoBehaviour, IClickable
    {
        [SerializeField] private Shacker _shacker;
        [SerializeField] private ColorChanger _colorChanger;
        [SerializeField] private EffectActivator _effectActivator;
        [SerializeField] private ClickCounter _clickCounter;

        public void OnClick()
        {
            _shacker.Shake();
            _colorChanger.ChangeColor();
            _effectActivator.Activate();
            _clickCounter.Increase();
        }
    }
}

