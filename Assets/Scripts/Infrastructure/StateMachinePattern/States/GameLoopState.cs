using UnityEngine;

namespace Infrastructure.StateMachinePattern.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        private GameObject _player;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            
        }
        
        public void Exit()
        {
            
        }
    }
}
