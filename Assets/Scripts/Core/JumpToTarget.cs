using System.Collections;
using Infrastructure;
using UnityEngine;

namespace Core
{
    public class JumpToTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _jumpHeight = 5f;
        [SerializeField] private float _jumpDuration = 1f;
        [SerializeField] private float _rotationSpeed = 360f;

        private static readonly int Close = Animator.StringToHash("Close");
        
        private FinishHatch _hatch;
        private bool _isJumping;

        private void OnEnable()
        {
            _hatch = GameObject.FindWithTag(Tags.FinishHatch).GetComponent<FinishHatch>();
            _hatch.FinishZoneEntered += JumpToPositionMethod;
        }

        private void OnDisable()
        {
            _hatch.FinishZoneEntered -= JumpToPositionMethod;
        }

        private void JumpToPositionMethod()
        {
            _target = _hatch.JumpTarget;

            if (!_isJumping) 
                StartCoroutine(JumpToPosition(_target.position));
        }

        private IEnumerator JumpToPosition(Vector3 targetPosition)
        {
            _isJumping = true;

            Vector3 startPosition = transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < _jumpDuration)
            {
                float t = elapsedTime / _jumpDuration;
            
                Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, t);

                float heightOffset = _jumpHeight * Mathf.Sin(Mathf.PI * t);
                currentPos.y += heightOffset;

                transform.position = currentPos;

                transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
        
            _hatch.Animator.SetTrigger(Close);
        }
    }
}
