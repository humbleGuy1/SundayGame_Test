using UnityEngine;

namespace SunGameStudio.Humanoid
{
    public class FootPrintsSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private GameObject _leftFoot;
        [SerializeField] private GameObject _rightFoot;
        [SerializeField] private FootPrintPrefab _leftFootPrint;
        [SerializeField] private FootPrintPrefab _rightFootPrint;

        private readonly int _left = 1;

        private void OnEnable() => _animator.StepDone += Spawn;

        private void OnDisable() => _animator.StepDone -= Spawn;

        private void Spawn(int footNumber)
        {
            if (footNumber == _left)
                Create(_leftFootPrint, _leftFoot.transform);
            else
                Create(_rightFootPrint, _rightFoot.transform);
        }

        private void Create(FootPrintPrefab prefab, Transform parentFoot)
        {
            var footPrint = Instantiate(prefab, parentFoot);
            footPrint.gameObject.transform.SetParent(null);
        }
    }
}

