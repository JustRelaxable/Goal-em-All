using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimatorController : MonoBehaviour
{
    [SerializeField]
    MainCharacterInputController mainCharacterInputController;

    [SerializeField]
    Transform ballForcePosition;

    public float kickPower = 1f;

    private Rigidbody ballRigidbody;
    private SphereCollider sphereCollider;

    public event Action OnBallKicked;


    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        ballRigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        mainCharacterInputController = FindObjectOfType<MainCharacterInputController>();
        mainCharacterInputController.OnTouchStart += MainCharacterInputController_OnTouchStart;
        if (mainCharacterInputController.touching)
            MainCharacterInputController_OnTouchStart(Vector3.zero);
        mainCharacterInputController.OnTouchEnd += MainCharacterInputController_OnTouchEnd; 
    }

    public void SetReferences(MainCharacterInputController inputController,Transform forcePosition)
    {
        mainCharacterInputController = inputController;
        ballForcePosition = forcePosition;
    }

    private void MainCharacterInputController_OnTouchEnd(Vector3 obj)
    {
        animator.SetBool("Dribbling", false);
    }

    private void MainCharacterInputController_OnTouchStart(Vector3 obj)
    {
        animator.SetBool("Dribbling", true);
    }

    public void OnKickAnimationEnd()
    {
        OnBallKicked?.Invoke();
        animator.enabled = false;
        animator.applyRootMotion = true;
        //transform.parent = null;
        transform.SetParent(null, true);
       
        ballRigidbody.isKinematic = false;
        ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        sphereCollider.isTrigger = false;
        ballRigidbody.MovePosition(ballForcePosition.position);
        ballRigidbody.AddForce(ballForcePosition.transform.forward * kickPower);
        //ballRigidbody.angularVelocity = Vector3.zero;

        UnsubscribeMainCharacterEvent();
        Destroy(gameObject, 5);
    }

    private void UnsubscribeMainCharacterEvent()
    {
        mainCharacterInputController.OnTouchStart-=MainCharacterInputController_OnTouchStart;
        mainCharacterInputController.OnTouchEnd -= MainCharacterInputController_OnTouchEnd;
    }
}
