using Cinemachine;
using Core;
using UnityEngine;
using Zenject;

namespace Logic
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private FinishHatch _finishHatch;
        private CinemachineVirtualCamera _virtualCamera;
        
        [Inject]
        public void Construct(Player player, FinishHatch finishHatch)
        {
            _player = player;
            _finishHatch = finishHatch;
        }

        private void Awake()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        private void OnEnable()
        {
            _finishHatch.FinishZoneEntered += StopFollow;
        }

        private void OnDisable()
        {
            _finishHatch.FinishZoneEntered -= StopFollow;

        }

        private void Start()
        {
            _virtualCamera.Follow = _player.transform;
            transform.rotation = new Quaternion(0,0,0,0);
        }
        
        private void StopFollow()
        {
            Debug.Log("HatchFinded");
            _virtualCamera.Follow = null;
        }
    }
}
