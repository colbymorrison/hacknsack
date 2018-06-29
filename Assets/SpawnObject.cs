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

    void Test(){
        Debug.Log("Spawning");
    }

    private void SpawnZombie(){
        GameObject game_obj = SpawnFood();
        game_obj.tag = "zombie";
    }

    public GameObject SpawnFood()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        return Instantiate(Personprefab, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f); //Red
        Gizmos.DrawCube(center, size);
    }
}