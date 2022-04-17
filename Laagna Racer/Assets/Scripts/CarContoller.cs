using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;
    private float currentbreakForce;
    private float modifier = 0;

    private bool turningRight = false;
    private bool turningLeft = false;


    [SerializeField] private int controlType;

    //Control Types Explained
    // 0 - Keyboard
    // 1 - Keyboard + Screen
    // 2 - Tilt

    [SerializeField] private float enginePower;
    [SerializeField] private float breakPower;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private int accelerationSpeed;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    private float currentSteerAngle;

    private void Start()
    {
        //Car Color Setup
        if (!PlayerPrefs.HasKey("VehicleColor"))
        {
            PlayerPrefs.SetString("VehicleColor", "FFFFFF");
        }

        //GYRO
        //rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();


        //rb.AddForce(transform.up * upSpeed, ForceMode.Acceleration);
        //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    public void VehicleSetColor()
    {
        ///???
    }


    private void GetInput()
    {
        verticalInput = 1;
        switch (controlType)
        {
            case 0:
                horizontalInput = Input.GetAxis(HORIZONTAL);
                isBreaking = Input.GetKey(KeyCode.Space);

                if (isBreaking)
                {
                    ApplyBreaking();
                }
                return;
            case 1:
                horizontalInput = Input.acceleration.x;
                Debug.Log(horizontalInput);


                if (horizontalInput < 0.19 && horizontalInput > -0.19)
                {
                    turningRight = false;
                    turningLeft = false;
                }
                else if (horizontalInput > 0.2)
                {
                    turningRight = true;
                }
                else if (horizontalInput < -0.2)
                {
                    turningLeft = true;
                }
                return;           
        }

    }
    public void SetControlType(int type)
    {
        controlType = type;
        Debug.Log("Control mode set to "+type);
    }
    // Here starts the Android Turning System
    public void pressedRight()
    {
        turningRight = true;
        //Debug.Log("right pressed");
    }
    public void pressedLeft()
    {
        turningLeft = true;
        //Debug.Log("left pressed");
    }
    public void releasedRight()
    {
        turningRight = false;
    }
    public void releasedLeft()
    {
        turningLeft = false;
    }
    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        backRightWheelCollider.brakeTorque = currentbreakForce;
        backLeftWheelCollider.brakeTorque = currentbreakForce;
    }
    private float AccelerationSpeed()
    {

        if (modifier < 1 && IsAccelerating())
        {
            modifier += (0.001f * accelerationSpeed);
            //Debug.Log(modifier);

        }
        if (!IsAccelerating())
        {
            modifier = 0;
        }
        return modifier;
    }
    private bool IsAccelerating()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            return true;
        }
        else
        {
            // return false;
            return true;
        }
    }

    private void HandleMotor()
    {
        float currentmodifier = AccelerationSpeed();
        backLeftWheelCollider.motorTorque = verticalInput * enginePower * currentmodifier;
        backRightWheelCollider.motorTorque = verticalInput * enginePower * currentmodifier;
        currentbreakForce = isBreaking ? breakPower : 100f;

    }
    public void SetCarToStart()
    {
        transform.position = Vector3.zero + new Vector3(0,1,0);
        transform.rotation = Quaternion.Euler(0, -270, 0) * Quaternion.identity;
        this.gameObject.SetActive(false);
    }
    private void HandleSteering()
    {
        if (turningRight)
        {
            horizontalInput = 1;
        }
        else if (turningLeft)
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
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
}