using UnityEngine;
using Zenject;

namespace Logic
{
    public class GameButton : MonoBehaviour
    {
        public Player Player;
        
        private WayPoints _wayPoints;

        [Inject]
        public void Construct(Player player)
        {
            Player = player;
        }

        public void GameButtonClicked()
        {
            Player.Move();
        }
    }
}
