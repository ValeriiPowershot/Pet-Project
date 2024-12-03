using Logic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class VirtualCameraInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _mainCameraPrefab;
        [SerializeField] private Transform _cameraInitialPosition;
        
        public override void InstallBindings()
        {
            PlayerCamera playerCamera = Container
                .InstantiatePrefabForComponent<PlayerCamera>(
                    _mainCameraPrefab,
                    _cameraInitialPosition.position,
                    quaternion.identity,
                    _cameraInitialPosition);
            
            Container.BindInstance(playerCamera).AsSingle();
        }
    }
}
