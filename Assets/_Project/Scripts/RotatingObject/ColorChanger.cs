using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;

        private readonly float _saturation = 1f;
        private readonly float _birghtness = 1f;

        public void ChangeColor()
        {
            _renderer.material.color = Randomazie();
        }

        private Color Randomazie()
        {
            float hue = Random.Range(0, 1.1f);

            return Color.HSVToRGB(hue, _saturation, _birghtness);
        }
    }
}

