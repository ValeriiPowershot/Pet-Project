using UnityEngine;

namespace Infrastructure.Services
{
    public interface ICinemachineService : IService
    {
        void SetupCamera(GameObject player);
    }
}
