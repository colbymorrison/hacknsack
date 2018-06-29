using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambulance_movement : MonoBehaviour {

    public Rigidbody ambulance;
    public float MotorForce, SteerForce, BrakeForce;
    public WheelCollider front_L_wheel, front_R_wheel, back_L_wheel, back_R_wheel;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float v = Input.GetAxis("Vertical") * MotorForce;
        float h = Input.GetAxis("Horizontal") * SteerForce;

        back_L_wheel.motorTorque = v;
        back_R_wheel.motorTorque = v;

        front_L_wheel.motorTorque = h;
        front_R_wheel.motorTorque = h;

        if(Input.GetKey(KeyCode.Space))
        {
            back_L_wheel.brakeTorque = BrakeForce;
            back_R_wheel.brakeTorque = BrakeForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            back_L_wheel.brakeTorque = 0;
            back_R_wheel.brakeTorque = 0;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            back_L_wheel.brakeTorque = BrakeForce;
            back_R_wheel.brakeTorque = BrakeForce;
        }
        else
        {
            back_L_wheel.brakeTorque = 0;
            back_R_wheel.brakeTorque = 0;
        }




        /* if (Input.GetKey("d"))
         {
             Quaternion deltaRotation = Quaternion.Euler(rotateRight * Time.deltaTime);
             ambulance.MoveRotation(ambulance.rotation * deltaRotation);

         }
         if (Input.GetKey("s"))
         {
           ambulance.AddForce(0,0, -50 * Time.deltaTime, ForceMode.VelocityChange);
         }
         if (Input.GetKey("w"))
         {
             ambulance.AddForce(0,0, 50 * Time.deltaTime, ForceMode.VelocityChange);
         }
         if (Input.GetKey("a"))
         {
             Quaternion deltaRotation = Quaternion.Euler(rotateLeft * Time.deltaTime);
             ambulance.MoveRotation(ambulance.rotation * deltaRotation);
         } */

    }
}
