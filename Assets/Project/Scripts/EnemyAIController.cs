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
        enemyCollisionController.OnCollidedWithBall += EnemyCollisionController_OnCollidedWithBall;
        CurrentUpdateDelegate = FollowPlayer;
    }

    private void EnemyCollisionController_OnCollidedWithBall()
    {
        navMeshAgent.enabled = false;
        CurrentUpdateDelegate -= FollowPlayer;
    }

    private void Update()
    {
        CurrentUpdateDelegate();
    }

    private void FollowPlayer()
    {
        navMeshAgent.SetDestination(playerGO.transform.position);
    }
}
