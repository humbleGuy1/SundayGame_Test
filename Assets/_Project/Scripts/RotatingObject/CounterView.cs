using TMPro;
using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void UpdateView(int value) => 
            _text.text = $"x{value}";
    }
}

