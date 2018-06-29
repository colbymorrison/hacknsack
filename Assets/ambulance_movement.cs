using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ambulance_movement : MonoBehaviour {

    public Rigidbody ambulance;
    public Text HitCount;

	// Use this for initialization
	void Start () {
        setHitCount(0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("a"))
        {
            ambulance.AddForce(-2000 * Time.deltaTime, 0,0);
        }
        if(Input.GetKey("s"))
        {
          ambulance.AddForce(0,0, -2000 * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            ambulance.AddForce(0,0, 2000 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            ambulance.AddForce(2000 * Time.deltaTime, 0, 0);
        }
    }

    public void setHitCount(int count){
        this.HitCount.text = "Hits: " + count;
    }
}
