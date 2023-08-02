using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private List<ParticleSystem> _effects;
        [Space(20f)]
        [ShowInInspector, ReadOnly] private readonly float _saturation = 1f;
        [ShowInInspector, ReadOnly] private readonly float _birghtness = 1f;

        public void ChangeColor()
        {
            _renderer.material.color = Randomazie();

            foreach (var effect in _effects)
            {
                effect.startColor = _renderer.material.color;
            }
        }

        private Color Randomazie()
        {
            float hue = Random.Range(0, 1.1f);

            return Color.HSVToRGB(hue, _saturation, _birghtness);
        }
    }
}

