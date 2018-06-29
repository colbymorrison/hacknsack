using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AmbulanceCollision : MonoBehaviour {
    public Text HitCount;
    private int numSaved;

    void Start(){
        numSaved = 0;
        setHit();
    }

	private void OnCollisionEnter(Collision coll)
	{
        GameObject collidedObj = coll.gameObject;

        //If we hit a zombie increment the count and delete the zombie
        if(collidedObj.tag == "zombie"){
            numSaved++;
            setHit();
            collidedObj.SetActive(false);
        }
	}

    private void setHit(){
        HitCount.text = "Saved: " + numSaved;
    }
}
