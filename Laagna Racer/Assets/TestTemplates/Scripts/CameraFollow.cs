using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public float positionSmoothness;
    [SerializeField] public float rotationSmoothness;
    public Transform Following;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Following.position, positionSmoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, Following.rotation, rotationSmoothness);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}
