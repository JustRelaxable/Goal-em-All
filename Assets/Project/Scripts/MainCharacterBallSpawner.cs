using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterBallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ball;
    [SerializeField]
    Transform ballSpawnerPosition;
    [SerializeField]
    Transform ballForcePosition;

    private MainCharacterInputController mainCharacterInputController;

    private void Awake()
    {
        mainCharacterInputController = GetComponent<MainCharacterInputController>();
    }

    public void SpawnBall()
    {
        GameObject b = Instantiate(ball, transform);
        b.GetComponent<BallAnimatorController>().SetReferences(mainCharacterInputController, ballForcePosition);
        b.transform.localPosition = ballSpawnerPosition.localPosition;
    }
}
