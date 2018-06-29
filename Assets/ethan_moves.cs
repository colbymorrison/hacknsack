using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ethan_moves : MonoBehaviour
{

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingL = false;
    private bool isRotatingR = false;
    private bool isWalking = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingR)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingL)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLoR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);

        if (rotateLoR == 1)
        {
            isRotatingR = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingR = false;
        }

        if (rotateLoR == 2)
        {
            isRotatingL = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingL = false;
        }
        isWandering = false;
    }
}