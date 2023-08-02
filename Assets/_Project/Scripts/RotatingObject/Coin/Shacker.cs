using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;


namespace SunGameStudio.RoatatingObject
{
    public class Shacker : MonoBehaviour
    {
        [Title("Duration"), HideLabel]
        [SerializeField] private float _duration;

        public void Shake() => transform.DOShakeScale(_duration);
    }
}

