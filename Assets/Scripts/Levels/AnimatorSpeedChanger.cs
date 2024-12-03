using System.Collections;
using UnityEngine;

namespace Levels
{
    public class AnimatorSpeedChanger : MonoBehaviour
    {
        private static readonly int Show = Animator.StringToHash("Show");
        private static readonly int Hide = Animator.StringToHash("Hide");

        [SerializeField] private Animator _animator;
        [SerializeField] private float _breakDuration;
        [SerializeField] private float _animatorSpeed;

        private void Start()
        {
            StartCoroutine(AnimationLoop());
        }

        private IEnumerator AnimationLoop()
        {
            _animator.speed = _animatorSpeed;
            
            while (true)
            {
                SwitchOn();
                yield return new WaitForSeconds(_breakDuration);
                SwitchOff();
                yield return new WaitForSeconds(_breakDuration);
            }
        }
        
        private void SwitchOn()
        {
            ResetAllTriggers();
            _animator.SetTrigger(Show);
        }

        private void SwitchOff()
        {
            ResetAllTriggers();
            _animator.SetTrigger(Hide);
        }
        
        private void ResetAllTriggers()
        {
            foreach (AnimatorControllerParameter parameter in _animator.parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Trigger)
                {
                    _animator.ResetTrigger(parameter.name);
                }
            }
        }
    }
}
