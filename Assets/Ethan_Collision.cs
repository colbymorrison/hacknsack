using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ethan_Collision : MonoBehaviour
{
    public Text InfectedCount;

	private void Start()
	{
	}

	private void Update()
	{
        int totalInfected = GameObject.FindGameObjectsWithTag("zombie").Length;
        InfectedCount.text = "Infected: " + totalInfected;
	}

	private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedObj = coll.gameObject;

        if (gameObject.CompareTag("zombie") || collidedObj.CompareTag("zombie")){
            SpawnObject.zombify(gameObject);
            SpawnObject.zombify(collidedObj);
        }
    }
}
