using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AmbulanceCollision : MonoBehaviour {
    private int count;
    private ambulance_movement ambulance;

    void Start(){
        GameObject ambulance_object = GameObject.Find("Ambulance");
        this.ambulance = ambulance_object.GetComponent<ambulance_movement>();
    }

	private void OnCollisionEnter(Collision coll)
	{
        GameObject gameObj = coll.gameObject;

        if(gameObj.tag == "zombie"){
            count++;
            ambulance.setHitCount(count);
            Destroy(gameObj);
        }
	}
}
