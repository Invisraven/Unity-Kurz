using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   private Rigidbody enemyRb;
    private GameObject player;
    private GameObject SpawnManager;
    private float speed=5;
    private float wave;
    private float size;
    // Start is called before the first frame update
    void Start()
    {   
        enemyRb= GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        size= Random.Range(0, 7);
        transform.localScale = new Vector3(size, size, size);
        //enemyRb.Mass=size;
        
    }

    // Update is called once per frame
    void Update()
    {   Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection*speed);

        if (transform.position.y <-10)
        {
            Destroy(gameObject);
        }
    }
}
