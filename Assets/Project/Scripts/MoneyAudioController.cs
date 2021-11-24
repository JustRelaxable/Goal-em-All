using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAudioController : MonoBehaviour
{
    [SerializeField]
    AudioClip pickupSound;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        audioSource.clip = pickupSound;
        audioSource.Play();
    }
}
