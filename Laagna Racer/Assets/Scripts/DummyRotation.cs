using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRotation : MonoBehaviour
{   
    [SerializeField] private float rotationSpeed;

    

    void FixedUpdate()
    {
        gameObject.transform.Rotate(0,(1 * rotationSpeed),0);
    }
}
