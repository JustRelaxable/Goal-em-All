using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionController : MonoBehaviour, IShootable
{
    [SerializeField]
    GameObject explosionParticle;

    [SerializeField]
    Transform particleSpawnPoint;

    [SerializeField]
    GameObject moneyPrefab;

    MeshRenderer meshRenderer;
    Collider boxCollider;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<Collider>();
    }


    public void OnBallCollide(Collision collision, GameObject ball)
    {
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        Instantiate(explosionParticle, particleSpawnPoint);
        SpawnMoney();
        Destroy(this.gameObject, 5);
    }

    private void SpawnMoney()
    {
        GameObject moneyGO = Instantiate(moneyPrefab);
        moneyGO.transform.position = particleSpawnPoint.position;
        moneyGO.transform.rotation = Quaternion.identity;
    }
}
