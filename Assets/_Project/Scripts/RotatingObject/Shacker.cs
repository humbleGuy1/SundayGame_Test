using UnityEngine;
using DG.Tweening;

namespace SunGameStudio.RoatatingObject
{
    public class Shacker : MonoBehaviour
    {
        [SerializeField] private float _duration;

        public void Shake() => transform.DOShakeScale(_duration);
    }
}

