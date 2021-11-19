using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject playerGO;
    EnemyCollisionController enemyCollisionController;


    private delegate void UpdateDelegate();
    UpdateDelegate CurrentUpdateDelegate;
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerGO = FindObjectOfType<MainCharacterInputController>().gameObject;
        enemyCollisionController = GetComponent<EnemyCollisionController>();
        enemyCollisionController.OnEnemyDead += EnemyCollisionController_OnCollidedWithBall;
        enemyCollisionController.OnPlayerTriggered += EnemyCollisionController_OnPlayerTriggered;
        //CurrentUpdateDelegate = FollowPlayer;
    }

    private void EnemyCollisionController_OnPlayerTriggered()
    {
        CurrentUpdateDelegate += FollowPlayer;
    }

    private void EnemyCollisionController_OnCollidedWithBall()
    {
        CurrentUpdateDelegate -= FollowPlayer;
        navMeshAgent.enabled = false;
        navMeshAgent = null;
        Destroy(this);
        //navMeshAgent.Stop();
    }

    private void Update()
    {
        CurrentUpdateDelegate?.Invoke();
    }

    private void FollowPlayer()
    {
        navMeshAgent?.SetDestination(playerGO.transform.position);
    }
}
