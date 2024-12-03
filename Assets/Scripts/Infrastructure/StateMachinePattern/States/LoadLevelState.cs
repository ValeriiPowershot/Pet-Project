using System;
using Infrastructure.FactoryPattern;
using Infrastructure.Services;
using Logic;
using UnityEngine;
using Cinemachine;

namespace Infrastructure.StateMachinePattern.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        public static event Action<GameObject> OnPlayerCreated;
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly ICinemachineService _cinemachineService;

        private GameObject _player;
        private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, ICinemachineService cinemachineService)
        {
            _loadingCurtain = loadingCurtain;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _cinemachineService = cinemachineService;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        private void OnLoaded()
        {
            _gameFactory.CreateHUD();
            _player = _gameFactory.CreatePlayer(GameObject.FindWithTag(Tags.InitialPoint));
            OnPlayerCreated?.Invoke(_player);
            

            _cinemachineVirtualCamera = GameObject
                .FindWithTag("MainCamera")
                .GetComponent<CinemachineVirtualCamera>();

            _cinemachineVirtualCamera.Follow = _player.transform;
            
            _cinemachineService.SetupCamera(_player);
            
            _stateMachine.Enter<GameLoopState>();
        }
    }
}
