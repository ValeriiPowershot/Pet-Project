using UnityEngine;

namespace UI
{
    public class TutorialPanelsSwitcher : MonoBehaviour
    {
        [SerializeField] private TutorialPanelsHolder _tutorialPanelsHolder;
        public int CurrentTutorial;

        public void NextTutorial()
        {
            OffAllPanels();
            OnPanel(CurrentTutorial);
        }

        private void OffAllPanels()
        {
            foreach (GameObject panel in _tutorialPanelsHolder.TutorialPanels) 
                panel.SetActive(false);
        }

        private void OnPanel(int panelIndex) =>
            _tutorialPanelsHolder.TutorialPanels[panelIndex].SetActive(true);
    }
}