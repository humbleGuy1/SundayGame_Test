using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class ImagePrefab : MonoBehaviour
    {
        [SerializeField] private Image _view;
        [SerializeField] private RectTransform _frame;
        [SerializeField] private ImageViewButton _button;

        public Image View => _view;

        public RectTransform Frame => _frame;

        private void Start() => _button.Disable();

        public void MakeInteractable() => _button.Enable();
    }
}

