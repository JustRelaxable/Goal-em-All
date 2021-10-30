using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaiinCharacterTransformController : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    private MainCharacterInputController mainCharacterInputController;
    public Vector3 characterRotationVector;
    public float characterRotationSensitivity = 5f;

    private void Awake()
    {
        mainCharacterInputController = GetComponent<MainCharacterInputController>();
    }

    private void Update()
    {
        if (!mainCharacterInputController.touching)
            return;
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraForwardHorizontal = new Vector3(cameraForward.x, 0, cameraForward.z);
        Vector3 cameraRight = camera.transform.right;
        Vector3 cameraRightHorizontal = new Vector3(cameraRight.x, 0, cameraRight.z);

        characterRotationVector = mainCharacterInputController.joystickVector.y * cameraForwardHorizontal + mainCharacterInputController.joystickVector.x * cameraRightHorizontal;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(characterRotationVector), Time.deltaTime * characterRotationSensitivity);

    }
}
