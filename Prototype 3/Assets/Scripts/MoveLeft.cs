using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{   private float speed=12;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    { 
         if(playerControllerScript.gameOver == false)
       {
            transform.Translate(Vector3.left*Time.deltaTime* speed) ;
       }
       if(transform.position.x <leftBound && gameObject.CompareTag("Obstacle"))
       {
        playerControllerScript.score=playerControllerScript.score+1;
        Destroy(gameObject);

       }
       
    }
    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.M.ToString())))
        {
            speed=speed*10;
        }else 
        {
            speed=12;
        }
    }
}
