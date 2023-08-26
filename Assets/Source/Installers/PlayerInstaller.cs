using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] public PlayerTouchMovement _playerMovement;
    [SerializeField] public Inventory _playerInventory;
    public override void InstallBindings()
    {
        Container.Bind<PlayerTouchMovement>().FromInstance(_playerMovement).AsSingle();
        Container.Bind<Inventory>().FromInstance(_playerInventory).AsSingle();
    }
}