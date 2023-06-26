using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class OpenGalleryButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start() => _button.onClick.AddListener(SceneLoader.Instance.LoadGalleryScene);

        private void OnDisable() => _button.onClick.RemoveListener(SceneLoader.Instance.LoadGalleryScene);
    }
}

