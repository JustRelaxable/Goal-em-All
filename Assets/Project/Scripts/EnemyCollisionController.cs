using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour, IShootable
{
   
    
    [SerializeField]
    protected GameObject ragdollRoot;
    protected Animator enemyAnimator;
    protected Rigidbody enemyRigidbody;
    protected CapsuleCollider enemyCapsuleCollider;
    protected EnemyLayerController enemyLayerController;

    public event Action OnEnemyDead;
    public event Action OnPlayerTriggered;

    public float pushBackForce = 1;

    protected bool collidedWithBall = false;

    protected void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyCapsuleCollider = GetComponent<CapsuleCollider>();
        enemyLayerController = GetComponent<EnemyLayerController>();
    }

    public virtual void OnBallCollide(Collision collision,GameObject ball)
    {
        if (collidedWithBall)
            return;
        collidedWithBall = true;
        OnEnemyDead?.Invoke();

        ragdollRoot.SetActive(true);
        enemyAnimator.enabled = false;
        //enemyRigidbody.isKinematic = true;
        //enemyRigidbody.useGravity = false;

        enemyRigidbody.AddForce(-collision.impulse * pushBackForce);
        //enemyCapsuleCollider.enabled = false;
        enemyLayerController.ChangeEnemyLayerToDead();
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggered?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MainCharacterInputController>().OnCollisionWithEnemy();
        }
        
    }

    protected void EnemyDead()
    {
        OnEnemyDead?.Invoke();
    }

}
