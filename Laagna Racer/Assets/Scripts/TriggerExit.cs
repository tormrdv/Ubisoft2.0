using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    public float destroyDelay = 20;

    public delegate void ExitAction();
    public static event ExitAction OnChunkExited;
    
    private bool exited = false;
    public void OnTriggerExit(Collider other)
    {
        CarTag carTag = other.GetComponent<CarTag>();
        if (carTag != null)
        {
            if (!exited)
            {
                exited = true;
                OnChunkExited();
                Debug.Log("Chunk Exited");
                StartCoroutine(WaitAndDeactivate());
            }
        }
    }

    IEnumerator WaitAndDeactivate()
    {
        yield return new WaitForSeconds(destroyDelay);

        transform.root.gameObject.SetActive(false);
    }

}
