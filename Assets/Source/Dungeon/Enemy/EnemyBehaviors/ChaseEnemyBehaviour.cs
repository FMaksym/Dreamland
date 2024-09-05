using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Animator _animator;

    private bool IsChase = false;
    private Transform playerTransform;

    
    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerTouchMovement>().transform;
    }

    
    public void ChaseMovement()
    {
        //Vector3 globalPlayerPosition = playerTransform.position;
        //Vector3 localPlayerPosition = transform.InverseTransformPoint(globalPlayerPosition);
        //navMeshAgent.SetDestination(localPlayerPosition);

        //gameObject.transform.LookAt(playerTransform.position);
        navMeshAgent.SetDestination(playerTransform.position);

        Debug.Log("I make ChaseMovemet to player");

        //navMeshAgent.Move(playerTransform.localPosition);
        //navMeshAgent.

        if (_animator != null && !IsChase)
        {
            IsChase = true;
            _animator.SetBool("Idle", false);
            _animator.SetBool("Chase", true);
        }
    }


    public void StopChase()
    {
        if (_animator != null && IsChase)
        {
            IsChase = false;
            _animator.SetBool("Chase", false);
            _animator.SetBool("Idle", true);
        }
    }
}
