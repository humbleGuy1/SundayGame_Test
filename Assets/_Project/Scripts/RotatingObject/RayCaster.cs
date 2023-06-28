using System.Collections;
using UnityEngine;

namespace SunGameStudio.RoatatingObject
{
    public class RayCaster : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private Camera _camera;
        [SerializeField, Min(0)] private float _cooldown;

        private Ray _ray;
        private float _timer;

        private void Update()
        {
            if (_playerInput.IsClicking)
            {
                TryCast();
            }
        }

        private void TryCast()
        {
            if (_timer <= 0)
            {
                _ray = _camera.ScreenPointToRay(Input.mousePosition);

                CheckHit(_ray);
            }
        }

        private void CheckHit(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out IClickable clickable))
                {
                    clickable.OnClick();

                    StartCoroutine(CountCooldown());
                }
            }
        }

        private IEnumerator CountCooldown()
        {
            _timer = _cooldown;

            while (_timer > 0)
            {
                _timer -= Time.deltaTime;

                yield return null;
            }
        }
    }
}

