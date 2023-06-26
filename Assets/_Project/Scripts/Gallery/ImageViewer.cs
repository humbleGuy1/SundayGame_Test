using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class ImageViewer : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private void Start() => 
            _image.sprite = ImageStorage.GetSelectedImage().sprite;
    }
}


