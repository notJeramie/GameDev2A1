using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetManager : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] targetTypes;
    public List<GameObject> target;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            SpawnTarget();
        }
    }
    public void SpawnTarget()
    {
        int targetIndex = Random.Range(0, targetTypes.Length);
        int spawnIndex = Random.Range(0, spawnPoint.Length);
        GameObject newSpawn = Instantiate(targetTypes[targetIndex], spawnPoint[spawnIndex].position + (Random.onUnitSphere * 2.0f), spawnPoint[spawnIndex].rotation);
        target.Add(newSpawn);
        // for (int i = 0; i < targetTypes.Length; i++)
        // {
        //    int targetIndex = Random.Range(0, targetTypes.Length);
        //    int spawnIndex = Random.Range(0, spawnPoint.Length);
        //    GameObject newSpawn = Instantiate(targetTypes[targetIndex], spawnPoint[spawnIndex].position + (Random.onUnitSphere * 2.0f), spawnPoint[spawnIndex].rotation);
        //    target.Add(newSpawn);
        // }
    }
}
