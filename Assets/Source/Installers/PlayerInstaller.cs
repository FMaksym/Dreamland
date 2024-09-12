using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] public PlayerTouchMovement _playerMovement;
    [SerializeField] public PlayerAbilities _playerAbilities;
    [SerializeField] public Inventory _playerInventory;
    public override void InstallBindings()
    {
        Container.Bind<PlayerTouchMovement>().FromInstance(_playerMovement).AsSingle().NonLazy();
        Container.Bind<PlayerAbilities>().FromInstance(_playerAbilities).AsSingle().NonLazy();
        Container.Bind<Inventory>().FromInstance(_playerInventory).AsSingle().NonLazy();
    }
}