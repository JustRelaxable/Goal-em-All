using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioController : MonoBehaviour
{
    [SerializeField]
    AudioClip[] kickSounds;

    [SerializeField]
    AudioClip wallHit;

    AudioSource audioSource;

    private void Awake()
    {
        GetComponent<BallAnimatorController>().OnBallKicked += BallAudioController_OnBallKicked;
        audioSource = GetComponent<AudioSource>();
    }

    private void BallAudioController_OnBallKicked()
    {
        var randomIndex = Random.Range(0, kickSounds.Length);
        audioSource.volume = 0.7f;
        audioSource.clip = kickSounds[randomIndex];
        audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = wallHit;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }
}
