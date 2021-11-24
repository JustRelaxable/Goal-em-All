using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioController : MonoBehaviour
{
    [SerializeField]
    AudioClip[] kickSounds;

    AudioSource audioSource;

    private void Awake()
    {
        GetComponent<BallAnimatorController>().OnBallKicked += BallAudioController_OnBallKicked;
        audioSource = GetComponent<AudioSource>();
    }

    private void BallAudioController_OnBallKicked()
    {
        var randomIndex = Random.Range(0, kickSounds.Length);
        audioSource.clip = kickSounds[randomIndex];
        audioSource.Play();
    }
}
