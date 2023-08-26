using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceRecycle
{
    string InputResourceName { get; }
    int MaxInputResource { get; }
    int MaxOutputResource { get; }
    string OutputResourceName { get; }
    int RecycleRate { get; }
    int MaxConversion { get; }
    List<Transform> InputResourceSpawnPoints { get; }
    List<GameObject> InputResourceObjects { get; }
    List<Transform> OutputResourceSpawnPoints { get; }
    List<GameObject> OutputResourceObjects { get; }

    void RecycleResource();
}
