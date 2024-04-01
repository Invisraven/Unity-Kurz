using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    public GameObject[ ] animalPrefabs;
    private float spawnRangeX =20;
    private float spawnPosZ =20;
    private float StartDelay = 2;
    private float SpawnIntervalFront = 3;
    private float SpawnIntervalLeft = 4;
    private float SpawnIntervalRight = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalFront",StartDelay, Random.Range(1,SpawnIntervalFront));
        InvokeRepeating("SpawnRandomAnimalLeft",StartDelay, Random.Range(1,SpawnIntervalLeft));
        InvokeRepeating("SpawnRandomAnimalRight",StartDelay, Random.Range(1,SpawnIntervalRight));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            
        }
    }
    void SpawnRandomAnimalFront() 
    {   //front spawn
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos =  new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos,animalPrefabs[animalIndex].transform.rotation);
    }
    void SpawnRandomAnimalLeft()  
    {  // left spawm
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnLeft = new Vector3(-25,0, Random.Range(-0, spawnPosZ));
        animalPrefabs[animalIndex].transform.Rotate(0.0f, -90.0f, 0.0f);
        Instantiate(animalPrefabs[animalIndex], spawnLeft, animalPrefabs[animalIndex].transform.rotation);
        animalPrefabs[animalIndex].transform.Rotate(0.0f, 90.0f, 0.0f);
    }  
    void SpawnRandomAnimalRight() 
    {  //Right spawn 
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnRight = new Vector3(25,0, Random.Range(-0, spawnPosZ));
        animalPrefabs[animalIndex].transform.Rotate(0.0f, 90.0f, 0.0f);        
        Instantiate(animalPrefabs[animalIndex], spawnRight, animalPrefabs[animalIndex].transform.rotation);
        animalPrefabs[animalIndex].transform.Rotate(0.0f, -90.0f, 0.0f);
    }
    
}
