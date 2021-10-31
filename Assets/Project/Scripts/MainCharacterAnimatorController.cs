using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAnimatorController : MonoBehaviour
{
    private Animator animator;
    private MainCharacterInputController mainCharacterInputController;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        mainCharacterInputController = GetComponent<MainCharacterInputController>();
        mainCharacterInputController.OnTouchEnd += MainCharacterInputController_OnTouchEnd;
    }

    private void MainCharacterInputController_OnTouchEnd(Vector3 obj)
    {
        animator.SetTrigger("RunToStop");
    }

    private void Update()
    {
        animator.SetFloat("RunningBlend", mainCharacterInputController.joystickVector.magnitude*5);
    }
}