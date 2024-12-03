using System.Collections;
using UnityEngine;

namespace Traps
{
    public abstract class TrapAnimatorBase : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected float _livingTime;
        [SerializeField] protected float _hideTime;

        private static readonly int Show = Animator.StringToHash("Show");
        private static readonly int Hide = Animator.StringToHash("Hide");

        private readonly int[] _allTriggers = { Show, Hide };
    
        protected virtual void Start()
        {
            StartCoroutine(RunLoopingAnimation());
            Debug.Log("Start Worked");
        }

        private IEnumerator RunLoopingAnimation()
        {
            while (true)
            {
                SetTrigger(_animator, Show);
                yield return new WaitForSeconds(_livingTime);

                SetTrigger(_animator, Hide);
                yield return new WaitForSeconds(_hideTime);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void SetTrigger(Animator animator, int triggerID)
        {
            foreach (int trigger in _allTriggers)
            {
                if (trigger != triggerID)
                    animator.ResetTrigger(trigger);
            }

            animator.SetTrigger(triggerID);
        }
    }
}
