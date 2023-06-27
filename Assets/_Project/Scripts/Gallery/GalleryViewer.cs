using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField, Min(0)] private int _totalImages;
        [SerializeField, Min(0)] private float _scrollThreshold;

        private List<ImagePrefab> _prefabs = new();

        private int _index = 1;
        private int _initialCount;

        private readonly int _screenHeight = Screen.height;

        private const string Url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        private const string JpjFormat = ".jpg";

        //private void OnEnable() => _scrollRect.onValueChanged.AddListener(OnScrollValueChanged);

        //private void OnDisable() => _scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);

        private void Start()
        {
            SpawnPrefabs();
            LoadInitialImages();
        }

        private void SpawnPrefabs()
        {
            for (int i = 0; i < _totalImages; i++)
            {
                _prefabs.Add(SpawnImagePrefab());
            }
        }

        private void LoadInitialImages()
        {
            _initialCount = CalculateInitialCount();

            for (int i = 0; i < _initialCount; i++)
            {
                LoadImage(_index);
            }
        }

        private void LoadImage(int index)
        {
            string imageUrl = Url + index + JpjFormat;

            StartCoroutine(LoadImageCoroutine(imageUrl, _prefabs[index - 1]));
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
                    LoadImage(_index);
                }
            }
        }

        private IEnumerator LoadImageCoroutine(string imageUrl, ImagePrefab prefab)
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(imageUrl);

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                prefab.View.sprite = CreateSprite(texture);
                prefab.MakeInteractable();
            }
            else
            {
                prefab.View.sprite = CreateSprite(_errorTexture);
            }
        }

        private Sprite CreateSprite(Texture2D texture)
        {
            float offset = 0.5f;

            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * offset);
        }
    }
}

