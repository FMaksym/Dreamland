using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceRecycle : MonoBehaviour, IResourceRecycle
{
    public string _inputResourceName;
    public string _outputResourceName;
    public int _conversionRate;
    public int _maxInputResources;
    public int _maxOutputResources;
    public int _currentConversion;
    public int _resourceCost;
    public int _playerResources;
    public bool IsCollecting;

    public List<Transform> _inputResourcesSpawnPoints;
    public List<Transform> _outputResourcesSpawnPoints;
    public List<GameObject> _inputObjects;
    public List<GameObject> _outputObjects;

    private float _timeSinceLastConversion;

    public string InputResourceName => _inputResourceName;
    public int MaxInputResource => _maxInputResources;
    public int MaxOutputResource => _maxOutputResources;
    public string OutputResourceName => _outputResourceName;
    public int RecycleRate => _conversionRate;
    public int MaxConversion => _maxOutputResources;
    public List<Transform> InputResourceSpawnPoints => _inputResourcesSpawnPoints;
    public List<GameObject> InputResourceObjects => _inputObjects;
    public List<Transform> OutputResourceSpawnPoints => _outputResourcesSpawnPoints;
    public List<GameObject> OutputResourceObjects => _outputObjects;

    private void Update()
    {
        if (!IsCollecting && GetActiveInputCount() >= _resourceCost)
        {
            _timeSinceLastConversion += Time.deltaTime;
            if (_timeSinceLastConversion >= RecycleRate && GetActiveOutputCount() < MaxOutputResource)
            {
                if (_currentConversion < MaxOutputResource)
                {
                    RecycleResource();
                    _timeSinceLastConversion = 0f;
                }
            }
        }
            
    }

    public void RecycleResource()
    {
        if (_timeSinceLastConversion >= RecycleRate && GetActiveOutputCount() < MaxOutputResource && GetActiveInputCount() >= _resourceCost)
        {
            GameObject outputObject = OutputResourceObjects[GetActiveOutputCount()];
            outputObject.SetActive(true);
            for (int i = 0; i < _resourceCost; i++)
            {
                GameObject inputObject = InputResourceObjects[GetActiveInputCount() - 1];
                inputObject.SetActive(false);
            }
            _currentConversion++;
            _timeSinceLastConversion = 0f;
        }
    }

    public int GetActiveInputCount()
    {
        return InputResourceObjects.Count(o => o.activeInHierarchy);
    }

    private int GetActiveOutputCount()
    {
        return OutputResourceObjects.Count(o => o.activeInHierarchy);
    }
}
