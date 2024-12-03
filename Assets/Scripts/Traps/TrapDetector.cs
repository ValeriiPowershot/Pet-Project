using Infrastructure;
using Logic;
using UnityEngine;
using Zenject;

namespace Traps
{
    public class TrapDetector : MonoBehaviour
    {
        private Player _player;
        
        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.PlayerTag))
                _player.Die();
        }
    }
}