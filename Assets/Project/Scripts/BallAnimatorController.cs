using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimatorController : MonoBehaviour
{
    [SerializeField]
    MainCharacterInputController mainCharacterInputController;

    private Animator animator;
    private void Awake()
    {
        mainCharacterInputController.OnTouchStart += MainCharacterInputController_OnTouchStart;
        mainCharacterInputController.OnTouchEnd += MainCharacterInputController_OnTouchEnd;
        animator = GetComponent<Animator>();
    }

    private void MainCharacterInputController_OnTouchEnd(Vector3 obj)
    {
        animator.SetBool("Dribbling", false);
    }

    private void MainCharacterInputController_OnTouchStart(Vector3 obj)
    {
        animator.SetBool("Dribbling", true);
    }
}
