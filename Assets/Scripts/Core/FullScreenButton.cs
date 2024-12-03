using Infrastructure.ObserverPattern;

namespace Core
{
    public class FullScreenButton : Subject
    {
        private void Start()
        {
            NotifyObservers();
        }
    }
}
