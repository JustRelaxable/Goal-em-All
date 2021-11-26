using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishlineCollisionController : MonoBehaviour
{
    public AudioSource end;
    public event Action OnPlayerTouchedFinishLine;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerTouchedFinishLine?.Invoke();
            collision.gameObject.transform.rotation = transform.rotation;
            end.Play();
        }
    }
}
