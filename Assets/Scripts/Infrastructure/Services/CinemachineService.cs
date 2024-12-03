using Cinemachine;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CinemachineService : ICinemachineService
    {
        private CinemachineVirtualCamera _virtualCamera;

        public CinemachineService(CinemachineVirtualCamera virtualCamera)
        {
            _virtualCamera = virtualCamera;
        }

        public void SetupCamera(GameObject player)
        {
            if (_virtualCamera == null || player == null)
                return;

            _virtualCamera.Follow = player.transform;
            _virtualCamera.LookAt = player.transform;
        }
    }
}
