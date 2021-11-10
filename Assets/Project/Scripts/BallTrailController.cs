using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrailController : MonoBehaviour
{
    [SerializeField]
    GameObject trail;

    private BallAnimatorController ballAnimatorController;
    private ParticleSystem trailParticle;

    private void Awake()
    {
        ballAnimatorController = GetComponent<BallAnimatorController>();
        ballAnimatorController.OnBallKicked += BallAnimatorController_OnBallKicked;
        trailParticle = trail.GetComponent<ParticleSystem>();
    }

    private void BallAnimatorController_OnBallKicked()
    {
        trail.SetActive(true);
    }

    public void ChangeTrailColor(Gradient gradient)
    {
        var col = trailParticle.colorOverLifetime;
        col.color = gradient;
    }
}
