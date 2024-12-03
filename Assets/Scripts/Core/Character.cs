using System;
using UnityEngine;

namespace Core
{
    public class Character : MonoBehaviour
    {
        private Action Died;

        private void OnEnable()
        {
            Died += Death;
        }

        private void OnDisable()
        {
            Died -= Death;
        }

        public void Death()
        {
            Died?.Invoke();
        }
    }
}
