using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.FactoryPattern
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);
        void CreateHUD();
    }
}
