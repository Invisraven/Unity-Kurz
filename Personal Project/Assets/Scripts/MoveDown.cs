using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{   
    public float speed;
    private float zBoundaries=-11;
    public PlayerController PlayerController;
    public SpawnManager SpawnManager;
    private bool GameStarted;
    private float repeatWidth;
    private Vector3 startPos;
    bool isConversionSuccessful;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>(); 
        SpawnManager = FindObjectOfType<SpawnManager>();  
        string collidedObjectTag = gameObject.tag;
        int numberCatch;
        if (int.TryParse(collidedObjectTag, out numberCatch))
        {
            numberCatch = int.Parse(collidedObjectTag);
        }

         isConversionSuccessful = int.TryParse(collidedObjectTag, out numberCatch);
    }

    // Update is called once per frame
    void Update()
    {   if(SpawnManager.GameStarted && !GameStarted)
        {   
            startPos= transform.position;
            PlayerController = FindObjectOfType<PlayerController>();
            repeatWidth = 6.024808f;
            GameStarted= true;
        }

        
        
        if(GameStarted && !PlayerController.GameOver && !PlayerController.GameEnded)
        {  
            
            if(gameObject.CompareTag("Plane"))
            { 
                transform.Translate(Vector3.right * Time.deltaTime *speed* ((PlayerController.Cisaccelerator+PlayerController.Pisaccelerator)*2));
                if (transform.position.z < startPos.x -repeatWidth)
                {
                    transform.position=startPos;
                }

            }
            else if(isConversionSuccessful)
            {
                transform.Translate(Vector3.back * Time.deltaTime *speed* PlayerController.Cisaccelerator);
                if(transform.position.z < zBoundaries)
                {
                    Destroy(gameObject);
                }
                if(PlayerController.GameOver || PlayerController.GameEnded)
                {
                    Destroy(gameObject);
                }
            }
            else 
            {
                transform.Translate(Vector3.back * Time.deltaTime *speed* PlayerController.Pisaccelerator);
                if(transform.position.z < zBoundaries)
                {
                    Destroy(gameObject);
                }
                if(PlayerController.GameOver || PlayerController.GameEnded)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
