using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlImproved : MonoBehaviour
{
    [SerializeField] private float enginePower;
    [SerializeField] private float maxSteerAngle;
    private int turnDirection = 0;
    private float turnSpeed = 1f;
    [SerializeField] private float startMaxVelocity = 3f;
    [SerializeField] private float velocityMultiplier = 0.003f;

    private int controlType = 0;
    //Control Type checks what sort of controls car is using. 0 - for button steering, 1 - for turning with tilting.
    



    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        IncreaseSpeedLimit();
    }
    private void HandleMotor()
    {   
        //Reduces engine power based on maximum allowed velocity.
        float velocity = startMaxVelocity - GetComponent<Rigidbody>().velocity.magnitude;
        Mathf.Clamp(velocity, 0.0f, 1000f);

        backLeftWheelCollider.motorTorque = enginePower * 1;
        backRightWheelCollider.motorTorque = enginePower * 1;
    }
    public void SetCarToStart()
    {
        transform.position = Vector3.zero + new Vector3(0, 1, 0);
        transform.rotation = Quaternion.Euler(0, -270, 0) * Quaternion.identity;
        gameObject.SetActive(false);
    }
    private void HandleSteering() //Tee see ümber (sujuvad pöörded)
    {
        switch (controlType)
        {
            case 0:
                frontLeftWheelCollider.steerAngle = Mathf.Lerp(frontLeftWheelCollider.steerAngle, turnDirection * maxSteerAngle, Time.deltaTime * turnSpeed);
                frontRightWheelCollider.steerAngle = Mathf.Lerp(-frontRightWheelCollider.steerAngle, turnDirection * maxSteerAngle, Time.deltaTime * turnSpeed);
                return;
            case 1:
                //Takes the X axis input of the phone. Mathf.Clamp limits the values between allowed steering angles
                float horizontalInput = Input.acceleration.x;
                horizontalInput = Mathf.Clamp(horizontalInput, -maxSteerAngle, maxSteerAngle);
                frontLeftWheelCollider.steerAngle = horizontalInput;
                frontRightWheelCollider.steerAngle = horizontalInput;
                return;
        }
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot * Quaternion.Euler(0, 0, 0);
        wheelTransform.position = pos;
        
    }


    public void SetTurningDirection(int direction)
    {
        turnDirection = direction;
    }

    private void IncreaseSpeedLimit()
    {
        //Increases max velocity over the game time
        startMaxVelocity = startMaxVelocity + ( Time.deltaTime * velocityMultiplier);
    }

}
