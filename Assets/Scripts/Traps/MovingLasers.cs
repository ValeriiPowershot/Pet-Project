using System.Collections;
using UnityEngine;

namespace Traps
{
    public class MovingLasers : MonoBehaviour
    {
        [SerializeField] private float _animationDelay;
        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        private void Start()
        {
            _animator.speed = 0;
            StartCoroutine(StartAnimation());
        }

        private IEnumerator StartAnimation()
        {
            yield return new WaitForSeconds(_animationDelay);
            _animator.speed = 1;
        }
    }
}
