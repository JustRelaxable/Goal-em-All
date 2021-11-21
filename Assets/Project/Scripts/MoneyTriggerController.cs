using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTriggerController : MonoBehaviour
{
    GameObject parentGO;
    private Animator animator;
    private SphereCollider sphereCollider;
    private Vector3 initialScale;
    private void Awake()
    {
        parentGO = transform.parent.gameObject;
        animator = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
        initialScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CoGoToPlayer());
            //animator.applyRootMotion = true;
            animator.enabled = false;
            sphereCollider.enabled = false;
        }
    }

    private IEnumerator CoGoToPlayer()
    {
        Vector3 initialPosition = transform.position;
        float duration = 1f;
        float currentTime = 0f;
        Transform playerTransform = FindObjectOfType<MainCharacterInputController>().gameObject.transform;
        while (currentTime<=duration)
        {
            transform.position = Vector3.Lerp(initialPosition, playerTransform.position, (currentTime / duration));
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, (currentTime / duration));
            currentTime += Time.deltaTime;
            yield return null;
        }
        Destroy(parentGO);
    }
}
