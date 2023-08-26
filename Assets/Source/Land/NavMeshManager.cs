using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _surface;

    public void BakeNavMesh()
    {
        _surface.BuildNavMesh();
    }
}
