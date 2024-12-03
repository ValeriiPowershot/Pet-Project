using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.ObserverPattern
{
    public abstract class Subject : MonoBehaviour
    {
        private List<IObserver> _observers = new();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            _observers.ForEach((_observers) => {
                _observers.OnNotify();
            });
        }
    }

}
