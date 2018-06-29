using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AmbulanceCollision : MonoBehaviour {
    public Text HitCount;
    public Text InfectedCount;
    private int numSaved;

    void Start(){
        numSaved = 0;
        setHit();
        setAlive();
    }

	private void OnCollisionEnter(Collision coll)
	{
        GameObject collidedObj = coll.gameObject;

        //If we hit a zombie increment the count and delete the zombie
        if(collidedObj.tag == "zombie"){
            numSaved++;
            setHit();
            collidedObj.SetActive(false);
            setAlive();
        }
	}

    private void setHit(){
        HitCount.text = "Saved: " + numSaved;
    }

    private void setAlive(){
        int totalInfected = GameObject.FindGameObjectsWithTag("zombie").Length;
        InfectedCount.text = "Infected: " + totalInfected;
    }
}
