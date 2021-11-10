using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionController : MonoBehaviour, IShootable
{
    bool readyToAffectBall = true;
    public void OnBallCollide(Collision collision,GameObject ball)
    {
        if (!readyToAffectBall)
            return;

        StartCoroutine(CollisionCooldown());
        var ballCollisionController = ball.GetComponent<BallCollisionController>();
        var ballRigidbody = ball.GetComponent<Rigidbody>();
        ApplyWallForceAndChangeTrailColor(ballCollisionController,ballRigidbody);
    }

    private void ChangeTrailColor(BallCollisionController ballCollisionController)
    {
        var ballTrailController = ballCollisionController.GetComponent<BallTrailController>();
        var wallCollisionIndex = ballCollisionController.WallCollisionCount;
        ballTrailController.ChangeTrailColor(ballCollisionController.wallCollisionSettings[wallCollisionIndex].trailColor);
    }

    private void ApplyWallForceAndChangeTrailColor(BallCollisionController ballCollisionController,Rigidbody ballRigidbody)
    {
        if(ballCollisionController.wallCollisionSettings.Length > ballCollisionController.WallCollisionCount)
        {
            var wallCollisionIndex = ballCollisionController.WallCollisionCount;
            ballRigidbody.velocity = ballRigidbody.velocity * ballCollisionController.wallCollisionSettings[wallCollisionIndex].velocityMultiplier;
            ChangeTrailColor(ballCollisionController);
            ballCollisionController.WallCollisionCount = wallCollisionIndex + 1;
        }
    }

    private IEnumerator CollisionCooldown()
    {
        readyToAffectBall = false;
        yield return new WaitForSeconds(0.1f);
        readyToAffectBall = true;
    }
}
