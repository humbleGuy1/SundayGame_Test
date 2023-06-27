using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Gallery
{
    public class AspectModeSwitchButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private AspectRatioFitter _aspectRatioFitter;

        private void OnEnable() => _button.onClick.AddListener(Switch);

        private void OnDisable() => _button.onClick.RemoveListener(Switch);

        private void Switch()
        {
            if (_aspectRatioFitter.aspectMode == AspectRatioFitter.AspectMode.EnvelopeParent)
                EnableFitMode();
            else
                EnableEnvelopeMode();
        }

        private void EnableFitMode()
        {
            _aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.FitInParent;
            _text.text = "Fit";
        }

        private void EnableEnvelopeMode()
        {
            _aspectRatioFitter.aspectMode = AspectRatioFitter.AspectMode.EnvelopeParent;
            _text.text = "Envelope";
        }
    }
}


