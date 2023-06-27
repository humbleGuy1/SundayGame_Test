using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

namespace SunGameStudio.Gallery
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private OrientationSwitcher _orientationSwitcher;

        private AsyncOperation _loadingOperation;

        private const string Gallery = "Gallery";
        private const string View = "View";

        public static SceneLoader Instance;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LoadGalleryScene() => 
            LoadScene(Gallery, _orientationSwitcher.SetPortrait);

        public void LoadViewScene() => 
            LoadScene(View, _orientationSwitcher.SetAuto);

        private void LoadScene(string name, Action onLoaded) => 
            StartCoroutine(Load(name, onLoaded));

        private IEnumerator Load(string name, Action onLoaded)
        {
            _loadingOperation = SceneManager.LoadSceneAsync(name);

            var waitUntilLoadingIsFinished = new WaitUntil(() => _loadingOperation.isDone);

            _loadingScreen.Show();

            yield return waitUntilLoadingIsFinished;

            onLoaded?.Invoke();
            _loadingScreen.Hide();
        }
    }
}

