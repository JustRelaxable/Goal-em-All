using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour, IShootable
{

    [SerializeField]
    private GameObject ragdollRoot;
    private Animator enemyAnimator;
    private Rigidbody enemyRigidbody;
    private CapsuleCollider enemyCapsuleCollider;

    public event Action OnCollidedWithBall;
    public event Action OnPlayerTriggered;

    public float pushBackForce = 1;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyCapsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void OnBallCollide(Collision collision,GameObject ball)
    {
        OnCollidedWithBall?.Invoke();

        ragdollRoot.SetActive(true);
        enemyAnimator.enabled = false;
        //enemyRigidbody.isKinematic = true;
        //enemyRigidbody.useGravity = false;

        enemyRigidbody.AddForce(-collision.impulse * pushBackForce);
        //enemyCapsuleCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggered?.Invoke();
        }
    }
}
