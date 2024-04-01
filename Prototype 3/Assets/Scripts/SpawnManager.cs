using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   public GameObject[] obstaclePrefab;
    private Vector3 spawnPos1 = new Vector3(25,2,0);
    private Vector3 spawnPos2 = new Vector3(25,4,0);
    private float startDelay = 2;
    private float repeatRate= 2;
    private PlayerController playerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {   int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        int obstacleCount = Random.Range(1, obstaclePrefab.Length);
        if (obstacleIndex == 1)
        {
            spawnPos1 = new Vector3(25,2,0);
            spawnPos2 = new Vector3(25,4,0);
        }else
        {
            spawnPos1 = new Vector3(25,0,0);
            spawnPos2 = new Vector3(25,2,0);
        }
        if(playerControllerScript.gameOver == false)
       {
        Instantiate(obstaclePrefab[obstacleIndex], spawnPos1, obstaclePrefab[obstacleIndex].transform.rotation);
        if (obstacleCount==2)
        Instantiate(obstaclePrefab[obstacleIndex], spawnPos2, obstaclePrefab[obstacleIndex].transform.rotation);
       }
    }
}
