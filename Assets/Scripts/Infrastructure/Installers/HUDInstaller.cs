using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class HUDInstaller : MonoInstaller
    {
        public GameObject HUD;
        
        public override void InstallBindings()
        {
            Container.InstantiatePrefab(HUD);
        }
    }
}
