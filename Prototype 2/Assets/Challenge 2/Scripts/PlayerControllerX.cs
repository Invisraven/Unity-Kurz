using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float _delayTime;
    private bool _dogAvailable = true;

    // Update is called once per frame
    void Update()
    {   
         // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && _dogAvailable)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _dogAvailable = false;
        }
         //set cooldown on dog 
        if (_delayTime < 0)
        {
            _dogAvailable = true;
            _delayTime = 1f;
        }
        else
        {
            _delayTime -= 1 * Time.deltaTime;
        }

    }
}
