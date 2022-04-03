using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPassing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DestroyAfterCountdown());
        
    }
    IEnumerator DestroyAfterCountdown()
    {
        yield return new WaitForSeconds(5);
        Destroy(transform.parent.gameObject);
        Debug.Log("CubeDestroyed");
    }
}

