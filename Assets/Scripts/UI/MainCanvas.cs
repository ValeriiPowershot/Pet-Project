using UnityEngine;

namespace UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject[] _panels;
        
        public void OpenPanel(GameObject panel)
        {
            HideAllPanels();
            panel.SetActive(true);
        }

        public void PlayButton()
        {
            Debug.Log("Play");
        }
        
        public void Quit() =>
            Application.Quit();

        private void HideAllPanels()
        {
            foreach (GameObject panel in _panels)
                panel.SetActive(false);
        }
    }
}
