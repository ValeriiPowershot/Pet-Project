using Logic;
using UnityEngine;
using Zenject;

namespace UI
{
    public class GameOverPanelActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        private Player _player;

        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }

        private void OnEnable()
        {
            _player.IsDead += ActivateGameOverPanel;
        }
        
        private void OnDisable()
        {
            _player.IsDead -= ActivateGameOverPanel;
        }

        private void ActivateGameOverPanel()
        {
            
        }
    }
}
