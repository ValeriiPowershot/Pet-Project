using Logic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        public Transform StartPoint;
        public GameObject PlayerPrefab;

        public override void InstallBindings()
        {
            Player player = Container
                .InstantiatePrefabForComponent<Player>(
                    PlayerPrefab,
                    StartPoint.position,
                    quaternion.identity,
                    null);

            Container.BindInstance(player).AsSingle();
        }
    }
}
    
