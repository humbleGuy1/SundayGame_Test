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

        private int _index = 1;
        private int _initialCount;
        private float _previousScrollPosition = 1;

        private readonly Factory _factory = new();
        private readonly List<ImagePrefab> _prefabs = new();

        private const string Url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        private const string JpjFormat = ".jpg";

        private void OnEnable() => 
            _scrollRect.onValueChanged.AddListener(OnScrollValueChanged);

        private void OnDisable() => 
            _scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);

        private void Start()
        {
            SpawnPrefabs();
            LoadInitialImages();
        }

        private void SpawnPrefabs()
        {
            for (int i = 0; i < _totalImages; i++)
            {
                _prefabs.Add(_factory.CreateObjectOfType(_imagePrefab, _parentGrid));
            }
        }

        private void LoadInitialImages()
        {
            _initialCount = CalculateInitialCount();

            for (int i = 0; i < _initialCount; i++)
            {
                LoadImage(_index);
                _index++;
            }
        }

        private void LoadImage(int index)
        {
            string imageUrl = Url + index + JpjFormat;

            StartCoroutine(LoadImageCoroutine(imageUrl, _prefabs[index - 1]));
        }

        private int CalculateInitialCount()
        {
            int imageHeight = Mathf.RoundToInt(_imagePrefab.Frame.rect.height);
            int rowsPerScreen = Mathf.FloorToInt((Screen.height - _layoutGroup.padding.top) /
                (imageHeight + _layoutGroup.spacing.y));

            return _layoutGroup.constraintCount * rowsPerScreen;
        }

        private void OnScrollValueChanged(Vector2 scrollPosition)
        {
            if (_index > _totalImages)
                _scrollRect.onValueChanged.RemoveListener(OnScrollValueChanged);

            float currentScrollPosition = scrollPosition.y;
            
            if (currentScrollPosition < _previousScrollPosition)
            {
                if (Mathf.Abs(_previousScrollPosition - currentScrollPosition) >= _scrollThreshold)
                {
                    LoadImage(_index);
                    _index++;
                    _previousScrollPosition = currentScrollPosition;
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
                prefab.View.sprite = _factory.CreateSprite(texture);
                prefab.MakeInteractable();
            }
            else
            {
                prefab.View.sprite = _factory.CreateSprite(_errorTexture);
            }
        }
    }
}

