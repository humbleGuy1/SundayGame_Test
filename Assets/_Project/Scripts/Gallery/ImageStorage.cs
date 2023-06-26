using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public static class ImageStorage
    {
        private static Image _selectedImage;

        public static void SetSelectedImage(Image image) => _selectedImage = image;

        public static Image GetSelectedImage() => _selectedImage;
    }
}


