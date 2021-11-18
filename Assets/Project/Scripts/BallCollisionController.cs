using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    public float wallDoubleMinimumSpeed = 10f;
    public int wallMaxSplitCount = 3;
    public int ballCurrentSplit = 0;

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
