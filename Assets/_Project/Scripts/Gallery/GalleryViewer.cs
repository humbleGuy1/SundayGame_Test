using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class GalleryViewer : MonoBehaviour
    {
        [SerializeField] private ImagePrefab _imagePrefab;
        [SerializeField] private Transform _parentGrid;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private int _totalImages;
        [SerializeField] private float _scrollThreshold;

        private int _index = 1;

        private readonly int ImagesPerRow = 2;

        private const string Url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        private const string JpjFormat = ".jpg";

        private void OnEnable() => _scrollRect.onValueChanged.AddListener(OnScrollValueChanged);

        private void OnDisable() => _scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);

        private void Start() => LoadInitialImages();

        private void OnScrollValueChanged(Vector2 scrollPosition)
        {
            float normalizedY = (scrollPosition.y - _scrollThreshold) / (1 - _scrollThreshold);
            print(normalizedY);

            if (normalizedY >= 0 && normalizedY <= 1)
            {
                if (normalizedY >= (_index / (float)_totalImages))
                {
                    LoadImage(_index, SpawnImagePrefab());
                }
            }
        }

        private ImagePrefab SpawnImagePrefab()
        {
            return Instantiate(_imagePrefab, _parentGrid);
        }

        private void LoadInitialImages()
        {
            if (_index >= _totalImages)
                return;

            for (int i = 0; i < ImagesPerRow * 4; i++)
            {
                LoadImage(_index, SpawnImagePrefab());
            }
        }

        private void LoadImage(int imageIndex, ImagePrefab image)
        {
            string imageUrl = Url + imageIndex + JpjFormat;

            Image view = image.View;
            StartCoroutine(LoadImageCoroutine(imageUrl, view));
            _index++;
        }

        private IEnumerator LoadImageCoroutine(string imageUrl, Image view)
        {
            var webRequest = UnityWebRequestTexture.GetTexture(imageUrl);
            {
                yield return webRequest.SendWebRequest();

                Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                view.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
            }
        }
    }
}

