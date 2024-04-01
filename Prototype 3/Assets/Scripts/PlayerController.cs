using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim; 
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpForce=10.0f;
    public float gravityModifier; 
    public int jump;
    public bool isOnGround =true;
    public bool gameOver;
    public int score=0;
    public int oldScore=0;
    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
       playerAnim = GetComponent<Animator>();
       playerAudio = GetComponent<AudioSource>();
       Physics.gravity *= gravityModifier;
       
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) && jump<2 && !gameOver)
       {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround= false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
            jump=jump+1;
            
       } 
       if (score!=oldScore)
       {    
        Debug.Log(score);
        oldScore=score;
       }
    }
    private void OnCollisionEnter(Collision collision){
        isOnGround= true;
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround= true;
            jump=0;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
           gameOver= true;
           Debug.Log("Game Over!") ;
           playerAnim.SetBool("Death_b",true);
           playerAnim.SetInteger("DeathType_int", 1);
           explosionParticle.Play();
           dirtParticle.Stop();
           playerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }
}
