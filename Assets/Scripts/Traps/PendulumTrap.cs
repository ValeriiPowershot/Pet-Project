using UnityEngine;

namespace Traps
{
    public class PendulumTrap : MonoBehaviour
    {
        [SerializeField] private float _pendulumSpeed;
        [SerializeField] private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        private void Start() =>
            _animator.speed = _pendulumSpeed;
    }
}
