using System.Collections;
using UnityEngine;


public class SpawnObject : MonoBehaviour
{

    public GameObject Personprefab; //Object not in the scence
    public Vector3 center;
    public Vector3 size;

    // Use this for initialization
    void Start()
    {
        SpawnZombie();
        InvokeRepeating("SpawnFood", 2.0f, 1.0f);
    }

    private void SpawnZombie(){
        GameObject game_obj = SpawnFood();
        zombify(game_obj);
    }

    public GameObject SpawnFood()
    {
        Debug.Log("Spawning");
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        GameObject obj = Instantiate(Personprefab, pos, Quaternion.identity);
        if (Random.Range(0, 4) == 0){
            zombify(obj);
        }
        return obj;
    }

    public static void zombify(GameObject obj){
        obj.tag = "zombie";
        obj.transform.Find("EthanBody").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}