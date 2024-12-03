using Infrastructure.ObserverPattern;
using UnityEngine;

namespace Core
{
    public class Movement : MonoBehaviour, IObserver
    {
        [SerializeField] private Subject _playerSubject;

        public void OnNotify()
        {
            print("MoveSystem Notified");
        }
    }
}
