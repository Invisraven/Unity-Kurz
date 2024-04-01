using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private variables
    private float speed = 5.0f;
    private float turnSpeed = 30f; 
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //player input
      horizontalInput = Input.GetAxis("Horizontal");
      forwardInput = Input.GetAxis("Vertical");
      // Move the vehicle forward  
      transform.Translate(Vector3.forward * Time.deltaTime *speed *forwardInput);
      // Rotate the vehicle forward  
      transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
