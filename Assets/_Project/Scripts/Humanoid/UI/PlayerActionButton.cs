using UnityEngine;
using UnityEngine.UI;

namespace SunGameStudio.Humanoid
{
    public abstract class PlayerActionButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;
        [SerializeField] protected UIMediator _mediator;

        private void OnEnable() => _button.onClick.AddListener(Act);

        private void OnDisable() => _button.onClick.RemoveListener(Act);

        protected abstract void Act();
    }
}


