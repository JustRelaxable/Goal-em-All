using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    public WallCollisionSettings[] wallCollisionSettings;
    public int WallCollisionCount { get; set; } = 0;
    private void OnCollisionEnter(Collision collision)
    {
        var iShootable = collision.gameObject.GetComponent<IShootable>();

        if(iShootable != null)
        {
            iShootable.OnBallCollide(collision,this.gameObject);
        }
    }

    [System.Serializable]
    public struct WallCollisionSettings
    {
        public float velocityMultiplier;
        public Gradient trailColor;
    }
}
