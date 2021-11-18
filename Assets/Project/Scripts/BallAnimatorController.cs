using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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

        var enemyAngleData = CheckIfEnemyIsInAngle();

        ballRigidbody.MovePosition(ballForcePosition.position);
        if (enemyAngleData != null)
        {
            var shootVector = Quaternion.AngleAxis(enemyAngleData.AngleBetween,enemyAngleData.CrossVector) * ballForcePosition.transform.forward;
            ballRigidbody.AddForce(shootVector * kickPower);
        }
        else
        {
            ballRigidbody.AddForce(ballForcePosition.transform.forward * kickPower);
        }

        //ballRigidbody.angularVelocity = Vector3.zero;

        //UnsubscribeMainCharacterEvent();
        Destroy(gameObject, 5);
    }

    private EnemyAngleData CheckIfEnemyIsInAngle()
    {
        var colliders = Physics.OverlapSphere(mainCharacterInputController.transform.position, 10f);
        colliders = colliders.OrderBy(x => Vector3.Distance(mainCharacterInputController.transform.position, x.transform.position)).ToArray();

        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyAIController enemyAIController;
            if(colliders[i].TryGetComponent<EnemyAIController>(out enemyAIController))
            {
                var angle = Vector3.SignedAngle(mainCharacterInputController.transform.forward, enemyAIController.transform.position - mainCharacterInputController.transform.position,mainCharacterInputController.transform.up);
                var crossVector = Vector3.Cross(mainCharacterInputController.transform.forward, enemyAIController.transform.position - mainCharacterInputController.transform.position);
                if(angle >= -30 && angle <= 30)
                {
                    if (angle < 0)
                        angle = -angle;
                    return new EnemyAngleData(enemyAIController.transform,angle,crossVector);
                }
            }
        }
        return null;
    }

    private void UnsubscribeMainCharacterEvent()
    {
        mainCharacterInputController.OnTouchStart-=MainCharacterInputController_OnTouchStart;
        mainCharacterInputController.OnTouchEnd -= MainCharacterInputController_OnTouchEnd;
    }

    private void OnDestroy()
    {
        UnsubscribeMainCharacterEvent();
    }
}

public class EnemyAngleData
{
    public Transform EnemyTransform { get;private set; }
    public float AngleBetween { get; private set; }

    public Vector3 CrossVector { get; private set; }
    public EnemyAngleData(Transform enemyTransform,float angleBetween,Vector3 crossVector)
    {
        EnemyTransform = enemyTransform;
        AngleBetween = angleBetween;
        CrossVector = crossVector;
    }
}