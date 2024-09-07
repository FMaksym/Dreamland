using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _surface;

    public void BakeNavMesh()
    {
        _surface.BuildNavMesh();
    }
}
