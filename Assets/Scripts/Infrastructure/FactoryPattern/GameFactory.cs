using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.FactoryPattern
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }
        
        public GameObject CreatePlayer(GameObject at) =>
            _assets.Instantiate(AssetPath.PlayerPath, at.transform.position);

        public void CreateHUD() =>
            _assets.Instantiate(AssetPath.HUDPath);
    }
}
