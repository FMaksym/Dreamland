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

    public void CollectResources(CollectType harvestType)
    {
        Collect(harvestType);
    }

    public void StopCollectResources(CollectType harvestType)
    {
        StopCollect(harvestType);
    }

    private void Collect(CollectType harvestType)
    {
        //if (harvestType == CollectType.Axe)
        //{
        //    _axe.gameObject.SetActive(true);
        //    animator.SetBool("IsChopWood", true);
        //}
        //else if (harvestType == CollectType.Pickaxe)
        //{
        //    _pickaxe.gameObject.SetActive(true);
        //    animator.SetBool("IsChopStone", true);
        //}
        //else if(harvestType == CollectType.Hand)
        //{
        //    animator.SetBool("IsHarvestFood", true);
        //}
        //else
        //{
        //    animator.SetBool("IsHarvestFoodFromGround", true);
        //}

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
        //if (harvestType == CollectType.Axe)
        //{
        //    animator.SetBool("IsChopWood", false);
        //    _axe.gameObject.SetActive(false);
        //}
        //else if (harvestType == CollectType.Pickaxe)
        //{
        //    animator.SetBool("IsChopStone", false);
        //    _pickaxe.gameObject.SetActive(false);
        //}
        //else if (harvestType == CollectType.Hand)
        //{
        //    animator.SetBool("IsHarvestFood", false);
        //}
        //else
        //{
        //    animator.SetBool("IsHarvestFoodFromGround", false);
        //}

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
