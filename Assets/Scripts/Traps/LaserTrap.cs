using UnityEngine;

namespace Traps
{
    public sealed class LaserTrap : TrapAnimatorBase
    {
        protected override void Start()
        {
            base.Start();
            Debug.Log("Start Worked");
        }
    }
}
