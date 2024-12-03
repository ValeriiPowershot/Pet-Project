using Infrastructure.ObserverPattern;
using Logic;
using UI;
using UnityEngine;

namespace Levels
{
    public class TutorialCollider : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserverZone;
        [SerializeField] private TutorialPanelsSwitcher _tutorialPanelsSwitcher;

        private void OnEnable() =>
            _triggerObserverZone.TriggerEnter += NextTutorial;

        private void OnDisable() =>
            _triggerObserverZone.TriggerEnter -= NextTutorial;

        private void NextTutorial(Collider obj)
        {
            _tutorialPanelsSwitcher.CurrentTutorial++;
            _tutorialPanelsSwitcher.NextTutorial();
            Destroy(gameObject);
        }
    }
}
