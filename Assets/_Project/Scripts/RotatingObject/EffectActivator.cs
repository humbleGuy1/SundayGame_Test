using UnityEngine;
using Sirenix.OdinInspector;

namespace SunGameStudio.RoatatingObject
{
    public class EffectActivator : MonoBehaviour
    {
        [ChildGameObjectsOnly]
        [SerializeField] private ParticleSystem _blastEffect;

        public void Activate() =>
            _blastEffect.Play();
    }
}

