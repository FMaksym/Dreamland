using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChopResources : MonoBehaviour
{
    [SerializeField] private GameObject _axe;
    [SerializeField] private GameObject _pickaxe;
    [SerializeField] private Animator animator;

    public enum CollectType
    {
        Axe,
        Pickaxe,
        Hand,
        HandFromGround
    }

    public void CollectResources(CollectType harvestType, Transform harvestableObject)
    {
        Collect(harvestType);
        gameObject.transform.LookAt(harvestableObject.position);
    }

    public void StopCollectResources(CollectType harvestType)
    {
        StopCollect(harvestType);
    }

    private void Collect(CollectType harvestType)
    {
        switch (harvestType)
        {
            case CollectType.Axe:
                animator.SetBool("IsChopWood", true);
                _axe.gameObject.SetActive(true);
                break;
            case CollectType.Pickaxe:
                animator.SetBool("IsChopStone", true);
                _pickaxe.gameObject.SetActive(true);
                break;
            case CollectType.Hand:
                animator.SetBool("IsHarvestFood", true);
                break;
            default:
                animator.SetBool("IsHarvestFoodFromGround", true);
                break;
        }
    }

    private void StopCollect(CollectType harvestType)
    {
        switch (harvestType)
        {
            case CollectType.Axe: 
                animator.SetBool("IsChopWood", false); 
                _axe.gameObject.SetActive(false); 
                break;
            case CollectType.Pickaxe:
                animator.SetBool("IsChopStone", false);
                _pickaxe.gameObject.SetActive(false);
                break; 
            case CollectType.Hand:
                animator.SetBool("IsHarvestFood", false);
                break;
            default: animator.SetBool("IsHarvestFoodFromGround", false);
                break;
        }
    }
}
