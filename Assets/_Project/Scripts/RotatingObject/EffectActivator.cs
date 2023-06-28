using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class EffectActivator : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _blastEffect;

        public void Activate() =>
            _blastEffect.Play();
    }
}

