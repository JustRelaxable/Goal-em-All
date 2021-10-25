using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterInputController : MonoBehaviour
{
    Vector3 firstTouchPosition;
    Vector3 presentTouchPosition;
    public Vector3 joystickVector;
    public bool touching = false;

    public event Action<Vector3> OnTouchEnd;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
            touching = true;
        }
        else if (Input.GetMouseButton(0))
        {
            presentTouchPosition = Input.mousePosition;
            Vector3 differenceVector = presentTouchPosition - firstTouchPosition;
            Vector3 screenIndependentDifferenceVector = new Vector3(differenceVector.x / Screen.width, differenceVector.y / Screen.height);
            joystickVector = Vector3.ClampMagnitude(screenIndependentDifferenceVector, 1f);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnTouchEnd?.Invoke(joystickVector);
            joystickVector = Vector3.zero;
            touching = false;
        }
    }
}
