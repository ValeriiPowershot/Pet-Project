using UnityEngine;

namespace Logic
{
    public class HUDPanelsToggler : MonoBehaviour
    {
        [SerializeField] private GameObject[] _panels;
        
        public void OpenPanel(GameObject panel)
        {
            CloseAllPanels();
            panel.SetActive(true);
        }
        
        private void CloseAllPanels()
        {
            foreach (GameObject panel in _panels) 
                panel.SetActive(false);
        }
    }
}
