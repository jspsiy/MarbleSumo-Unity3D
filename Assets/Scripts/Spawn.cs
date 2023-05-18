using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, GenerateSpawnPos(), enemy.transform.rotation);        
    }

    Vector3 GenerateSpawnPos()
    {
        Vector3 position = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
        return position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
