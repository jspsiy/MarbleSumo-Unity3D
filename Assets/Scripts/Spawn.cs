using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerUp;
    bool powerUpSpawned = false;
    int wave = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(wave);
    }

    void SpawnEnemy(int enemySize)
    {
        for (int x =0; x< enemySize; x++)
        {
            Instantiate(enemy, GenerateSpawnPos(), enemy.transform.rotation);
        }


    }
    Vector3 GenerateSpawnPos( )
    {
        Vector3 position = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
        return position;
    }

    // Update is called once per frame
    void Update()
    {
        int enemyFound = FindObjectsOfType<EnemyControl>().Length;
        if (enemyFound ==0)
        {
            wave = wave + 1;
            SpawnEnemy(wave);
        }
        if (powerUpSpawned == false )
        {
            Debug.Log("Power up spawned");
            powerUpSpawned = true;
            Instantiate(powerUp, GenerateSpawnPos(), powerUp.transform.rotation);
            StartCoroutine(PowerUpCD());
        }
    }
    IEnumerator PowerUpCD()
    {
        yield return new WaitForSeconds(7);
        powerUpSpawned = false;
    }
}
