using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private EnemyCollisionController enemyCollisionController;
    private Animator animator;
    public AudioSource enemy_hit;

    private MainCharacterInputController mainCharacterInputController;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyCollisionController = GetComponent<EnemyCollisionController>();
        enemyCollisionController.OnPlayerTriggered += EnemyCollisionController_OnPlayerTriggered;
        enemyCollisionController.OnEnemyDead += EnemyCollisionController_OnEnemyDead;
        mainCharacterInputController = FindObjectOfType<MainCharacterInputController>();
        mainCharacterInputController.OnCollisionWithEnemy += EnemyAnimatorController_OnCollisionWithEnemy;
    }

    private void EnemyCollisionController_OnEnemyDead()
    {
        mainCharacterInputController.OnCollisionWithEnemy -= EnemyAnimatorController_OnCollisionWithEnemy;
    }

    private void EnemyAnimatorController_OnCollisionWithEnemy()
    {
        animator.SetTrigger("PlayerDead");
    }

    private void EnemyCollisionController_OnPlayerTriggered()
    {
        animator.SetTrigger("PlayerTriggered");
    }


}
