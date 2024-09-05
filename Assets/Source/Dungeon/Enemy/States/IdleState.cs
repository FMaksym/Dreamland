using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public PlayerDetectionInRadius _playerDetection;
    public IdleEnemyBehaviour _idleBehaviour;
    public ChaseState chaseState;
    public bool canSeeThePlayer;

    public override State RunCurrentState()
    {
        if (_playerDetection.IsPlayerDetectedForChase())
        {
            _idleBehaviour.RotateTowardsPlayer();
            _idleBehaviour.DetectPlayer();

            if (_idleBehaviour.IsPlayerDetected())
            {
                _idleBehaviour.StartChasing(); 
                return chaseState;
            }
            else
            {
                _idleBehaviour.StopChasing();
                return this;
            }
        }
        else
        {
            return this;
        }
    }
}
