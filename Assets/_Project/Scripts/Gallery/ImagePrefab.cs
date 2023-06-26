using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class ImagePrefab : MonoBehaviour
    {
        [SerializeField] private Image _view;
        [SerializeField] private RectTransform _frame;

        public Image View => _view;

        public RectTransform Frame => _frame;
    }
}

