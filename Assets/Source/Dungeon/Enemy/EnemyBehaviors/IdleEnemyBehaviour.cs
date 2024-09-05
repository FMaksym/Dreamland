using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using Zenject;

public class IdleEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Animator _animator;

    private Vector3 currentPosition;
    private Transform playerTransform;
    private bool isPlayerDetected = false;
    private bool isIdle = true;

    private void Start()
    {
        navMeshAgent = navMeshAgent?.GetComponent<NavMeshAgent>();
        playerTransform = FindObjectOfType<PlayerTouchMovement>().transform;
        navMeshAgent.enabled = true;
        currentPosition = transform.position;
        navMeshAgent.speed = enemyData.movementSpeed;
        //InvokeRepeating(nameof(IdleMovement), 1f, enemyData.idleDuration);
    }

    private void IdleMovement()
    {
        currentPosition = transform.position;

        if (isIdle)
        {
            //_animator.SetBool("Idle", false);
            //_animator.SetBool("Walk", true);

            ActivateNextAnimation("Idle", "Walk");
            Vector3 randomDirection = Random.insideUnitSphere * enemyData.idleRadius;
            randomDirection += currentPosition;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, enemyData.idleRadius, NavMesh.AllAreas);

            
            navMeshAgent.SetDestination(hit.position);
            //Debug.Log("Idle");
        }

        //_animator.SetBool("Walk", false);
        //_animator.SetBool("Idle", true);

        ActivateNextAnimation("Walk", "Idle");
    }

    public void DetectPlayer()
    {
        isPlayerDetected = false;
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, enemyData.detectionRadius))
        {
            if (hit.collider.GetComponent<PlayerTouchMovement>())
            {
                isPlayerDetected = true;
                isIdle = false;
                //Debug.Log("Enemy detect player");
            }
        }
    }

    public void RotateTowardsPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * enemyData.rotationSpeed);
        //Debug.Log("Enemy Rotate");
    }
    
    public void StartChasing()
    {
        isIdle = false;
    }

    
    public void StopChasing()
    {
        isIdle = true;
        navMeshAgent.ResetPath();
    }

    public bool IsPlayerDetected() => isPlayerDetected;

    private void ActivateNextAnimation(string prevAnim, string nextAnim)
    {
        if (_animator != null)
        {
            _animator.SetBool(prevAnim, false);
            _animator.SetBool(nextAnim, true);

            Debug.Log($"Chage {prevAnim} to false and {nextAnim} to true");

        }
    }
}
