using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public PlayerDetectionInRadius _playerDetection;
    public ChaseEnemyBehaviour _chaseBehaviour;
    public IdleState idleState;
    public AttackState attackState;

    public override State RunCurrentState()
    {
        if (_playerDetection.IsPlayerDetectedForChase() && _playerDetection.IsPlayerDetectedForAttack())
        {
            Debug.Log("I change chase to attack");
            return attackState;
        }
        else if (_playerDetection.IsPlayerDetectedForChase() && !_playerDetection.IsPlayerDetectedForAttack())
        {
            Debug.Log("I chase to player");
            _chaseBehaviour.ChaseMovement();
            return this;
        }
        else
        {
            _chaseBehaviour.StopChase();
            Debug.Log("I change chase to idle");
            return idleState;
        }
    }
}
