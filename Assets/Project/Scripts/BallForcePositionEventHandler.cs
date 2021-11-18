using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForcePositionEventHandler : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<FinishlineCollisionController>().OnPlayerTouchedFinishLine += BallForcePositionEventHandler_OnPlayerTouchedFinishLine;
    }

    private void BallForcePositionEventHandler_OnPlayerTouchedFinishLine()
    {
        gameObject.SetActive(false);
    }
}
