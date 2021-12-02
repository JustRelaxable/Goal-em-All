using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    GameObject joystick;
    [SerializeField]
    GameObject knob;
    [SerializeField]
    float knobMultiplier;
    MainCharacterInputController mainCharacterInputController;
    RectTransform joystickRectTransform;
    RectTransform knobRectTransform;
    bool isJoystickActive = false;
    private void Awake()
    {
        joystick.SetActive(false);
        joystickRectTransform = joystick.GetComponent<RectTransform>();
        knobRectTransform = knob.GetComponent<RectTransform>();
        mainCharacterInputController = FindObjectOfType<MainCharacterInputController>();
        mainCharacterInputController.OnTouchStart += MainCharacterInputController_OnTouchStart;
        mainCharacterInputController.OnTouchEnd += MainCharacterInputController_OnTouchEnd;
    }

    private void MainCharacterInputController_OnTouchEnd(Vector3 obj)
    {
        joystick.SetActive(false);
        isJoystickActive = false;
    }

    private void MainCharacterInputController_OnTouchStart(Vector3 mousePositon)
    {
        joystick.SetActive(true);
        isJoystickActive = true;
        joystickRectTransform.anchoredPosition = mousePositon;
    }

    private void Update()
    {
        HandleKnob();
    }

    private void HandleKnob()
    {
        if (isJoystickActive)
        {
            knobRectTransform.anchoredPosition = mainCharacterInputController.joystickVector * knobMultiplier;
        }
    }
}
