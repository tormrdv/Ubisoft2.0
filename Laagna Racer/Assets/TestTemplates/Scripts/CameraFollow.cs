using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public float positionSmoothness;
    [SerializeField] public float rotationSmoothness;
    [SerializeField] public float cameraRisingMulitplier;
    public Transform Following;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CarPosition = Following.transform.position;
        CarPosition.y += VelocityToCamera();
        transform.position = Vector3.Lerp(transform.position,CarPosition, positionSmoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, Following.rotation, rotationSmoothness);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));

    }
    public void SetCameraToStart()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    public float VelocityToCamera()
    {
        float endValue;
        float speedOfCar = Following.GetComponent<Rigidbody>().velocity.magnitude;
        endValue = speedOfCar * cameraRisingMulitplier;

        return endValue;
    }
}
