using System;
using Infrastructure;
using Infrastructure.ObserverPattern;
using UnityEngine;

namespace Core
{
    public class FinishHatch : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _finishZone;
        
        private static readonly int Finish = Animator.StringToHash("Finish");

        public Animator Animator;
        public Transform JumpTarget;
        public Action FinishZoneEntered;
        
        private void OnEnable() =>
            _finishZone.TriggerEnter += FinishZoneEnter;

        private void OnDisable() =>
            _finishZone.TriggerEnter -= FinishZoneEnter;

        private void FinishZoneEnter(Collider obj)
        {
            if (!obj.CompareTag(Tags.PlayerTag)) return;
            FinishZoneEntered?.Invoke();
            Animator.SetTrigger(Finish);
            
        }
    }
}
