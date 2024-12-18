using TanksIO.Common.Core.Player;
using UnityEngine;
using Zenject;

namespace TanksIO.BootStrap.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private TankController _controller;
        [SerializeField] private TargetsContainer _targetContainer;
        [SerializeField] private TankRotationJoystick _joystickRotationJoystick;
        [SerializeField] private TankRotation _tankRotation;

        public override void InstallBindings()
        {
            Container.Bind<TankController>().FromInstance(_controller).AsSingle();
            Container.Bind<TargetsContainer>().FromInstance(_targetContainer).AsSingle();
            Container.Bind<TankRotationJoystick>().FromInstance(_joystickRotationJoystick).AsSingle();
            Container.Bind<TankRotation>().FromInstance(_tankRotation).AsSingle();
        }
    }
}