using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFood : MonoBehaviour
{
    [SerializeField] public float growTime = 15f;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool isGrowing = true;

    private PickingFood _pickUpFood;

    private void Awake()
    {
        _pickUpFood = GetComponent<PickingFood>();
    }

    void Update()
    {
        if (isGrowing)
        {
            timer += Time.deltaTime;
            if (timer >= growTime)
            {
                foodPrefab.SetActive(true);
                isGrowing = false;
                timer = 0f;
                _pickUpFood.isPickedUp = false;
            }
        }
    }

    public void HarvestFood()
    {
        timer = 0f;
        isGrowing = true;
    }
}
