using UnityEngine;
using DG.Tweening;

namespace SunGameStudio.RoatatingObject
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private int _x;
        [SerializeField] private int _y;
        [SerializeField] private int _z;
        [SerializeField] private float _duration;

        private void Start()
        {
            transform.DORotate(new Vector3(_x, _y, _z), _duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
        }
    }
}


