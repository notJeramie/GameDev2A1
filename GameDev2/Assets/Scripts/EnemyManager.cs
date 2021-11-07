using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{

    public Transform[] spawnPoint;
    public GameObject[] enemyTypes;
    public List<GameObject> enemy;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log((i + 1));
        }
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Remove(Enemy toRemove)
    {
        enemy.Remove(toRemove.gameObject);
        Debug.Log(enemy.Count);
    }


    [ContextMenu("SpawnEnemy")]
    public void SpawnEnemy()
    {
        for (int i = 0; i < enemyTypes.Length; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoint.Length);
            GameObject newSpawn = Instantiate(enemyTypes[i], spawnPoint[spawnIndex].position + (Random.onUnitSphere * 2.0f), spawnPoint[spawnIndex].rotation);
            enemy.Add(newSpawn);
            Debug.Log(enemy);
        }

        Debug.Log("Total: " + enemy.Count);
    }

}
