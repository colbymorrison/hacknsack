using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambulance_movement : MonoBehaviour {

    public Rigidbody ambulance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("w"))
        {
            ambulance.AddForce(-2000 * Time.deltaTime, 0,0);
        }
        if(Input.GetKey("a"))
        {
          ambulance.AddForce(0,0, -2000 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            ambulance.AddForce(0,0, 2000 * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            ambulance.AddForce(2000 * Time.deltaTime, 0, 0);
        }

    }
}
