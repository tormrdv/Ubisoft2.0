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


    [SerializeField] private int controlMode;

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

    private void Update()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    

    private void GetInput()
    {
        verticalInput = 1;
        if (controlMode == 0)
        {
            horizontalInput = Input.GetAxis(HORIZONTAL);
            isBreaking = Input.GetKey(KeyCode.Space);

            if (isBreaking)
            {
                ApplyBreaking();
            }
        }

    }// Here starts the Android Turning System
    public void TurningRight()
    {
        horizontalInput = -1f;
    }
    public void TurningLeft()
    {
        horizontalInput = 1f;
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
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
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
        frontLeftWheelCollider.motorTorque = verticalInput * enginePower * currentmodifier;
        frontRightWheelCollider.motorTorque = verticalInput * enginePower * currentmodifier;
        currentbreakForce = isBreaking ? breakPower : 100f;

    }
    private void HandleSteering()
    {
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
        wheelTransform.rotation = rot*Quaternion.Euler(0,0,90);
        wheelTransform.position = pos; 
    }
}