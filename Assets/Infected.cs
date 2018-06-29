using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infected : MonoBehaviour
{
    public Text InfectedCount;

    private void Start()
    {

    }

    public void setAlive()
    {
        int totalInfected = GameObject.FindGameObjectsWithTag("zombie").Length;
        InfectedCount.text = "Infected: " + totalInfected;
    }
}

