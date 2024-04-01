using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange =10.0f;
    public float zRange =15.0f;
    public int Life =3;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("Player Lifes="+ Life); 
       Debug.Log("Score=0");
    }

    // Update is called once per frame
    void Update()
    {   //keep player in bounds
        if (transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 15-zRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, 15-zRange);
        }
        if (transform.position.z > zRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Launch a projectile from a player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);         
        }
    }
}
