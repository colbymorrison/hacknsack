
using UnityEngine;

public class follow : MonoBehaviour {

    public Transform ambulance;
    public Vector3 offset;

	// Update is called once per frame
	void Update () {
        transform.position = ambulance.position + offset;
	}
}
