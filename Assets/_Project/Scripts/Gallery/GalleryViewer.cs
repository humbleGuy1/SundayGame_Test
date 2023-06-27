using System;
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
        [SerializeField] private Texture2D _errorTexture;
        [SerializeField] private GridLayoutGroup _layoutGroup;
        [SerializeField] private int _totalImages;
        [SerializeField] private float _scrollThreshold;

        private int _index = 1;
        private int _initialCount;

        private readonly int _screenHeight = Screen.height;

        private const string Url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        private const string JpjFormat = ".jpg";

        private void OnEnable() => _scrollRect.onValueChanged.AddListener(OnScrollValueChanged);

        private void OnDisable() => _scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);

        private void Start() => LoadInitialImages();

        private void LoadInitialImages()
        {
            _initialCount = CalculateInitialCount();
            print(_initialCount);

            for (int i = 0; i < _initialCount; i++)
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

        private int CalculateInitialCount()
        {
            int imageHeight = Mathf.RoundToInt(_imagePrefab.Frame.rect.height);
            int rowsPerScreen = Mathf.FloorToInt((_screenHeight - _layoutGroup.padding.top) /
                (imageHeight + _layoutGroup.spacing.y));

            return _layoutGroup.constraintCount * rowsPerScreen;
        }

        private ImagePrefab SpawnImagePrefab()
        {
            return Instantiate(_imagePrefab, _parentGrid);
        }

        private void OnScrollValueChanged(Vector2 scrollPosition)
        {
            float normalizedY = (scrollPosition.y - _scrollThreshold) / (1 - _scrollThreshold);
            print(normalizedY + " " + _index / (float)_totalImages);

            if (normalizedY >= 0 && normalizedY <= 1)
            {
                if (normalizedY >= (_index / (float)_totalImages))
                {
                    LoadImage(_index, SpawnImagePrefab());
                }
            }
        }

        private IEnumerator LoadImageCoroutine(string imageUrl, Image view)
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(imageUrl);

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                view.sprite = CreateSprite(texture);
            }
            else
            {
                view.sprite = CreateSprite(_errorTexture);
            }
        }

        private Sprite CreateSprite(Texture2D texture)
        {
            float offset = 0.5f;

            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * offset);
        }
    }
}

