using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace SunGameStudio.RoatatingObject
{
    public class Rotator : MonoBehaviour
    {
        [BoxGroup("Axis", centerLabel: true)]
        [GUIColor("Red")]
        [SerializeField] private int _x;

        [BoxGroup("Axis")]
        [GUIColor("Green")]
        [SerializeField] private int _y;

        [BoxGroup("Axis")]
        [GUIColor("Cyan")]
        [SerializeField] private int _z;
        
        [Title("Duration")]
        [HideLabel]
        [SerializeField] private float _duration;

        private void Start()
        {
            transform.DORotate(new Vector3(_x, _y, _z), _duration, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
        }
    }
}


