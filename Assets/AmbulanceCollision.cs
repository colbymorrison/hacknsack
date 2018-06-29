using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceCollision : MonoBehaviour {
	private void OnCollisionEnter(Collision coll)
	{
        GameObject gameObj = coll.gameObject;
        Debug.Log("Tag: " + gameObj.tag);

        if(gameObj.tag == "zombie"){
            Destroy(gameObj);
        }
	}
}
