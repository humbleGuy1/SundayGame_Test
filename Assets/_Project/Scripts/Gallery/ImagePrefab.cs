using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class ImagePrefab : MonoBehaviour
    {
        [SerializeField] private Image _view;

        public Image View => _view;

        public bool IsLoaded => _view.sprite is not null;
    }
}

