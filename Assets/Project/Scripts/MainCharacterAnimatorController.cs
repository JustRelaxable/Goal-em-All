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
    }
    private void Update()
    {
        animator.SetFloat("RunningBlend", mainCharacterInputController.joystickVector.magnitude);
    }
}
