using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class NavMeshInstaller : MonoInstaller
{
    [SerializeField] private NavMeshManager _navMesh;
    public override void InstallBindings()
    {
        Container.Bind<NavMeshManager>().FromInstance(_navMesh).AsSingle();
    }
}