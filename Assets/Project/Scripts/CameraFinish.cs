using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFinish : MonoBehaviour
{
    [SerializeField]
    Transform cameraFinishTransform;

    private CameraFollow cameraFollow;
    private void Awake()
    {
        cameraFollow = GetComponent<CameraFollow>();
        FindObjectOfType<FinishlineCollisionController>().OnPlayerTouchedFinishLine += CameraFinish_OnPlayerTouchedFinishLine;
    }

    private void CameraFinish_OnPlayerTouchedFinishLine()
    {
        cameraFollow.enabled = false;
        LerpToFinishPosition();
    }

    private void LerpToFinishPosition()
    {
        StartCoroutine(CoLerpToFinish());
    }

    private IEnumerator CoLerpToFinish()
    {
        float duration = 1f;
        float current = 0f;

        Vector3 firstPos = transform.position;
        Quaternion firstRot = transform.rotation;

        while (current <= duration)
        {
            transform.rotation = Quaternion.Lerp(firstRot, cameraFinishTransform.rotation, (current / duration)); 
            transform.position = Vector3.Lerp(firstPos, cameraFinishTransform.position, (current / duration));
            current += Time.deltaTime;
            yield return null;
        }
    }
}
