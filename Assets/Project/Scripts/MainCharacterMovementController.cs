using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    private Rigidbody rigidbody;
    private MainCharacterInputController mainCharacterInputController;
    private MaiinCharacterTransformController maiinCharacterTransformController;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainCharacterInputController = GetComponent<MainCharacterInputController>();
        maiinCharacterTransformController = GetComponent<MaiinCharacterTransformController>();
    }

    private void FixedUpdate()
    {
        //transform.Translate(new Vector3(0,0,mainCharacterInputController.joystickVector.magnitude) * Time.deltaTime * movementSpeed,Space.Self);
        //rigidbody.velocity = maiinCharacterTransformController.characterRotationVector * movementSpeed;
        
        rigidbody.MovePosition(Vector3.MoveTowards(transform.position, transform.position + transform.forward, mainCharacterInputController.joystickVector.magnitude * Time.deltaTime * movementSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
