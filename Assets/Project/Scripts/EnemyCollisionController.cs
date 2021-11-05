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

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyCapsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void OnBallCollide(Collision collision)
    {
        OnCollidedWithBall?.Invoke();

        ragdollRoot.SetActive(true);
        enemyAnimator.enabled = false;
        //enemyRigidbody.isKinematic = true;
        //enemyRigidbody.useGravity = false;

        enemyRigidbody.AddForce(Vector3.up *100000);
        //enemyCapsuleCollider.enabled = false;
    }
}
