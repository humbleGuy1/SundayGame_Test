using System;
using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class ClickCounter : MonoBehaviour
    {
        [SerializeField] private CounterView _counterView;
  
        private int _counter;

        public event Action ValueReached;

        public void Increase()
        {
            _counter++;
            _counterView.UpdateView(_counter);

            if(_counter % 3 == 0)
                ValueReached?.Invoke();
        }
    }
}

