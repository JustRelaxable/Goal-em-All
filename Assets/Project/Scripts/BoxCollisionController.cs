using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionController : MonoBehaviour, IShootable
{
    [SerializeField]
    GameObject explosionParticle;

    [SerializeField]
    Transform particleSpawnPoint;

    MeshRenderer meshRenderer;
    Collider boxCollider;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }



    public void OnBallCollide(Collision collision, GameObject ball)
    {
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        Instantiate(explosionParticle, particleSpawnPoint);
        Destroy(this.gameObject, 5);
    }
}