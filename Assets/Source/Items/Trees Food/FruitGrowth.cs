using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGrowth : MonoBehaviour
{
    public  GameObject[] foodPrefabs;

    [SerializeField] private float growTime = 15f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool isGrowing = true;
    
    private FruitPicking _fruitPicking;

    private void Awake()
    {
        _fruitPicking = GetComponentInChildren<FruitPicking>();
    }

    void Update()
    {
        if (isGrowing)
        {
            timer += Time.deltaTime;
            if (timer >= growTime)
            {
                foreach (var food in foodPrefabs)
                {
                    food.SetActive(true);
                }
                isGrowing = false;
                timer = 0f;
                _fruitPicking.isPickedUp = false;
            }
        }
    }

    public void HarvestFood()
    {
        timer = 0f;
        isGrowing = true;
    }
}
