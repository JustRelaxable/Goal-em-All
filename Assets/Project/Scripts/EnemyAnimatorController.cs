using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private EnemyCollisionController enemyCollisionController;
    private Animator animator;
    public AudioSource enemy_hit;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyCollisionController = GetComponent<EnemyCollisionController>();
        enemyCollisionController.OnPlayerTriggered += EnemyCollisionController_OnPlayerTriggered;
        FindObjectOfType<MainCharacterInputController>().OnCollisionWithEnemy += EnemyAnimatorController_OnCollisionWithEnemy;
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
