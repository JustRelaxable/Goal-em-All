using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var iShootable = collision.gameObject.GetComponent<IShootable>();

        if(iShootable != null)
        {
            iShootable.OnBallCollide(collision);
        }
    }
}
