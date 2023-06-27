using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class ImageViewButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ImagePrefab _image;

        private void OnEnable()
        {
            _button.onClick.AddListener(SceneLoader.Instance.LoadViewScene);
            _button.onClick.AddListener(StoreImage);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SceneLoader.Instance.LoadViewScene);
            _button.onClick.RemoveListener(StoreImage);
        }

        public void Disable() => _button.interactable = false;

        public void Enable() => _button.interactable = true;

        private void StoreImage() => ImageStorage.SetSelectedImage(_image.View);
    }
}


