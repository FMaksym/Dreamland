using System.Collections.Generic;
using UnityEngine;

public interface IResourceFactory
{
    string ResourceName { get; }
    int ProductionRate { get; }
    int MaxProduction { get; }
    List<Transform> SpawnPoints { get; }
    List<GameObject> ResourceObjects { get; }

    void ProduceResource();
}
