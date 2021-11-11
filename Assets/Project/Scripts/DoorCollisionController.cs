using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionController : MonoBehaviour, IShootable
{
    [SerializeField]
    GameObject explosionParticle;

    [SerializeField]
    Transform explosionSpawnPoint;


    private DoorEnemyCounter doorEnemyCounter;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private void Awake()
    {
        doorEnemyCounter = GetComponent<DoorEnemyCounter>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void OnBallCollide(Collision collision, GameObject ball)
    {
        if(doorEnemyCounter.EnemyCount == 0)
        {
            explosionParticle.SetActive(true);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            Destroy(gameObject, 5);
        }
    }
}
