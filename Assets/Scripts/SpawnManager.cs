using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject oxygenPrefab;
    private Vector3 spawnPosition= new Vector3(20,15,3);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private float spawnRange = 7.0f;


     // player selection class


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnOxygenPrefab", startDelay, repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnOxygenPrefab()
    {
        Instantiate(oxygenPrefab, GenerateSpawnPosition(), oxygenPrefab.transform.rotation) ; 
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(9,30);
        float spawnPosZ = Random.Range(-9,14);

        Vector3 randomPos = new Vector3(spawnPosX,5, spawnPosZ);
        return randomPos;
    }
}
