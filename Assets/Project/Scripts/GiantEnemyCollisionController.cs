using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantEnemyCollisionController : EnemyCollisionController
{
    [SerializeField]
    private int giantEnemyHealth = 4;
    private int damageTkaen = 0;

    private Vector3 giantEnemyScale;

    private void Awake()
    {
        base.Awake();
        giantEnemyScale = transform.localScale;
    }

    public override void OnBallCollide(Collision collision, GameObject ball)
    {
        damageTkaen++;
        transform.localScale = Vector3.Lerp(giantEnemyScale, Vector3.one, (damageTkaen / (float)giantEnemyHealth));

        if(damageTkaen >= giantEnemyHealth)
        {
            EnemyDead();
            ragdollRoot.SetActive(true);
            enemyAnimator.enabled = false;
            enemyRigidbody.AddForce(-collision.impulse * pushBackForce);
            enemyLayerController.ChangeEnemyLayerToDead();
            Destroy(gameObject, 5);
        }
    }
}
