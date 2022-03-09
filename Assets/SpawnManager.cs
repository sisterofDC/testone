using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemySpawn;
    public Vector2 EnemySpawnPositionX;
    private float Spawn_Time = 2.0f;
    private float Enemy_Time = 0f;
    // Start is called before the first frame update
    private string functionName = "spawnEnemyFunction";
    public void spawn_function()
    {
        Enemy_Time = Enemy_Time + Time.deltaTime;
        if (Enemy_Time >= Spawn_Time)
        {
            Instantiate(EnemySpawn);
            Enemy_Time = 0f;
        }
    }

    public void spawnEnemyFunction()
    {

        Vector3 EnemyNewVector = new Vector3(
            Random.Range(EnemySpawnPositionX[0], EnemySpawnPositionX[1]),
            EnemySpawn.transform.position.y, 
            EnemySpawn.transform.position.z);

        Instantiate(EnemySpawn,EnemyNewVector,EnemySpawn.transform.localRotation);
    }

    void Start()
    {
        InvokeRepeating(functionName, 0, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
