using UnityEngine;
using DG.Tweening;

namespace SunGameStudio.RoatatingObject
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _targetY;
        [SerializeField] private float _duration;

        private void Start()
        {
            transform.DOMoveY(_targetY, _duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }
    }
}


