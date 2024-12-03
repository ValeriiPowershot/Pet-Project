using Core;
using Logic;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class WayPointsInstaller : MonoInstaller
    {
        [SerializeField] private WayPoints _wayPoints;
        [SerializeField] private FinishHatch _finishHatch;
        
        public override void InstallBindings() 
        {
            Container.BindInstance(_wayPoints).AsSingle();
            Container.BindInstance(_finishHatch).AsSingle();
        }
    }
}
