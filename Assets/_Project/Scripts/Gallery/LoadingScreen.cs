using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;

namespace SunGameStudio.Gallery
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TMP_Text _percent;
        [SerializeField, Min(0)] private float _fillTime;

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1f;
            StartCoroutine(FilProgressBar());
        }

        public void Hide() => StartCoroutine(WaitBeforeFade());
        
        private IEnumerator WaitBeforeFade()
        {
            float delay = _fillTime + 2f;

            var waitForSeconds = new WaitForSeconds(delay);

            yield return waitForSeconds;
            yield return StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            float delta = 0.02f;
            float delay = 0.01f;

            var waitForSeconds = new WaitForSeconds(delay);

            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= delta;

                yield return waitForSeconds;
            }

            gameObject.SetActive(false);
        }

        private IEnumerator FilProgressBar()
        {
            float elapsedTime = 0;
            float value;
            float roundedNumber;

            while (elapsedTime <= _fillTime)
            {
                value = Mathf.Lerp(0, 1f, elapsedTime / _fillTime);
                elapsedTime += Time.deltaTime;

                _progressBar.value = value;
                roundedNumber = (float)Math.Round(value, 2);
                _percent.text = $"{roundedNumber * 100}%";

                yield return null;
            }

            _progressBar.value = 1f;
            _percent.text = "100%";
        }
    }
}

