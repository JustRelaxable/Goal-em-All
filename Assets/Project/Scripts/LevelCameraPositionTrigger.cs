using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCameraPositionTrigger : MonoBehaviour
{
    [SerializeField]
    private Vector3 maxCameraOffset;

    [SerializeField]
    private Vector3 minCameraOffset;

    private CameraFollow cameraFollow;
    private BoxCollider boxCollider;
    private bool playerInside = false;
    private GameObject mainCharacterGO;
    private float boxMinX;
    private float boxMaxX;
    private float boxMinMaxDifference;
    private void Awake()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        boxCollider = GetComponent<BoxCollider>();
        boxMinX = boxCollider.bounds.center.x - boxCollider.bounds.extents.x;
        boxMaxX = boxCollider.bounds.center.x + boxCollider.bounds.extents.x;
        boxMinMaxDifference = boxMaxX - boxMinX;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetCameraOffset(CalculateCameraPositionVector());
            mainCharacterGO = null;
            playerInside = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(playerInside)
            cameraFollow.LevelVector = CalculateCameraPositionVector();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCharacterGO = other.gameObject;
            playerInside = true;
            SetCameraOffset(CalculateCameraPositionVector());
        }
    }

    private Vector3 CalculateCameraPositionVector()
    {
        float percentage = Mathf.InverseLerp(boxMaxX,boxMinX, mainCharacterGO.transform.position.x);
        //percentage = ((mainCharacterGO.transform.position.x - boxMinX) / boxMinMaxDifference);
        return Vector3.Lerp(minCameraOffset, maxCameraOffset, percentage);
    }

    private void SetCameraOffset(Vector3 vector)
    {
        cameraFollow.LevelVector = vector;
    }
}
