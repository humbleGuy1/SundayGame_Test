using System.Collections;
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

        private void Start()
        {
            Disable();
            StartCoroutine(Wait());
        }


        private void OnDisable()
        {
            _button.onClick.RemoveListener(SceneLoader.Instance.LoadViewScene);
            _button.onClick.RemoveListener(StoreImage);
        }

        private void StoreImage() => ImageStorage.SetSelectedImage(_image.View);

        private void Disable()
        {
            _button.interactable = false;
            _button.enabled = false;
        }

        private void Enable()
        {
            _button.enabled = true;
            _button.interactable = true;
        }

        private IEnumerator Wait()
        {
            yield return new WaitUntil(() => _image.IsLoaded);

            Enable();
        }
    }
}


