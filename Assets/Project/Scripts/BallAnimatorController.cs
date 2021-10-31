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

    private Animator animator;
    private void Awake()
    {
        mainCharacterInputController.OnTouchStart += MainCharacterInputController_OnTouchStart;
        mainCharacterInputController.OnTouchEnd += MainCharacterInputController_OnTouchEnd;
        animator = GetComponent<Animator>();
        ballRigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
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
        animator.enabled = false;
        animator.applyRootMotion = true;
        //transform.parent = null;
        transform.SetParent(null, true);
       
        ballRigidbody.isKinematic = false;
        sphereCollider.isTrigger = false;
        ballRigidbody.MovePosition(ballForcePosition.position);
        ballRigidbody.AddForce(ballForcePosition.transform.forward * kickPower);
        //ballRigidbody.angularVelocity = Vector3.zero;
    }
}
