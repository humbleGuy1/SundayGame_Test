using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class ClickCounter : MonoBehaviour
    {
        [SerializeField] private CounterView _counterView;
  
        private int _counter;

        public void Increase()
        {
            _counter++;
            _counterView.UpdateView(_counter);
        }
    }
}

