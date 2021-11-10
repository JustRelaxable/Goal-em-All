using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private EnemyCollisionController enemyCollisionController;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyCollisionController = GetComponent<EnemyCollisionController>();
        enemyCollisionController.OnPlayerTriggered += EnemyCollisionController_OnPlayerTriggered;
    }

    private void EnemyCollisionController_OnPlayerTriggered()
    {
        animator.SetTrigger("PlayerTriggered");
    }
}
