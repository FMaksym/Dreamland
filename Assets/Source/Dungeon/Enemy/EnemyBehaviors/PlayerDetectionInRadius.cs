using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDetectionInRadius : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    public bool isPlayerInDetectionRadius;
    public bool isPlayerInAttackRadius;

    public bool IsPlayerDetectedForChase()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemyData.detectionRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.GetComponent<PlayerTouchMovement>())
            {
                //Debug.Log("Player in detection radius");

                isPlayerInDetectionRadius = true;
                return isPlayerInDetectionRadius;
            }
        }

        //Debug.Log("Player is not in detection radius");
        isPlayerInDetectionRadius = false;
        return isPlayerInDetectionRadius;
    }

    public bool IsPlayerDetectedForAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemyData.attackRadius);

        foreach (Collider collider in hitColliders)
        {
            if (collider.GetComponent<PlayerTouchMovement>())
            {
                //Debug.Log("Player in attack radius");

                isPlayerInAttackRadius = true;
                return isPlayerInAttackRadius;
            }
        }

        isPlayerInAttackRadius = false;
        return isPlayerInAttackRadius;
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyData.detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyData.attackRadius);
    }
}
