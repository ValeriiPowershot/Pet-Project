using Cinemachine;
using Infrastructure.AssetManagement;
using Infrastructure.FactoryPattern;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.StateMachinePattern.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }
        
        public void Exit()
        {
            
        }
        
        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("1");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IPersistantProgressService>(new PersistantProgressService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));

            CinemachineVirtualCamera cinemachineVirtualCamera = GameObject.FindWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();
            CinemachineService cinemachineService = new CinemachineService(cinemachineVirtualCamera);
            AllServices.Container.RegisterSingle<ICinemachineService>(cinemachineService);
        }
    }
}
