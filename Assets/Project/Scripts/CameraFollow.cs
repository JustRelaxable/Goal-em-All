using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject gameObjectToFollow;

    private Vector3 differenceVector;
    private void Awake()
    {
        differenceVector = transform.position - gameObjectToFollow.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = gameObjectToFollow.transform.position + differenceVector;
    }
}
