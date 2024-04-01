using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed =15.0f;
    private Rigidbody playerRb;
    private float xbound =23;
    private float zbound =9;
    public int progress=1;
    public float Cisaccelerator=1;
    public float Pisaccelerator=1;

    public float accelerator=0.3f;
    public SpawnManager SpawnManager;


    private int NumberRight=0;
    public int Lives=3;
    public bool GameOver=false;
    public bool GameEnded=false;
    public HoldButton upButton;
    public HoldButton downButton;
    public HoldButton leftButton;
    public HoldButton rightButton; 
    public string LetterGood="................";
    private int RFull=1;
    private int AFull=2;
    private int DFull=1;
    private int KFull=2;
    private int OFull=2;
    private int LFull=1; 
    private int UFull=1;
    private int CFull=2;
    private int VFull=1;
    private int IFull=1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
        upButton = GameObject.Find("Up").GetComponent<HoldButton>();
        downButton = GameObject.Find("Down").GetComponent<HoldButton>();
        leftButton = GameObject.Find("Left").GetComponent<HoldButton>();
        rightButton = GameObject.Find("Right").GetComponent<HoldButton>();
        SpawnManager = FindObjectOfType<SpawnManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayer();  
        if(upButton.IsButtonPressed())  
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } 
        if(downButton.IsButtonPressed())  
        {
             transform.Translate(Vector3.back * speed * Time.deltaTime);
        } 
        if(leftButton.IsButtonPressed())  
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        } 
        if(rightButton.IsButtonPressed())  
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        } 

    }
    
    //Player movement
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed );
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed );

    }

    //keep player in boundaries
    void ConstrainPlayer()
    {
        if(transform.position.x <-xbound)
        {
            transform.position = new Vector3(-xbound,transform.position.y, transform.position.z);
        }
        if(transform.position.x > xbound)
        {
            transform.position = new Vector3(xbound,transform.position.y, transform.position.z);
        }

        if(transform.position.z <-zbound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, -zbound);
        }
        if(transform.position.z > zbound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, zbound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        Destroy(other.gameObject);
        string collidedObjectTag = other.gameObject.tag;
        int numberCatch;
        if (int.TryParse(collidedObjectTag, out numberCatch))
        {
            numberCatch = int.Parse(collidedObjectTag);
        }

        // Pomocou int.TryParse():
        bool isConversionSuccessful = int.TryParse(collidedObjectTag, out numberCatch);

        if (isConversionSuccessful)
        {
            if (NumberRight==numberCatch)
            {
                NumberRight += 1;
                progress +=1;
                Cisaccelerator += 1f;
            }            
            else
            {   Lives -=1;

            }
        }
        
        if(other.gameObject.CompareTag("Gum"))
        {
            Lives +=1;
        }
        else if(!isConversionSuccessful)
        {
            if(other.gameObject.CompareTag("R") && RFull!=0) 
            {   RFull-=1;
                LetterGood = LetterGood.Substring(0,0) +"R"+ LetterGood.Substring(1);
                Pisaccelerator += accelerator;
            } 
            
            else if(other.gameObject.CompareTag("A") && AFull!=0) 
            {   AFull-=1;
                if(AFull>0)
                {
                    LetterGood = LetterGood.Substring(0,1) +"A"+ LetterGood.Substring(2);
                    Pisaccelerator += accelerator;
                }
                else
                {
                    LetterGood = LetterGood.Substring(0,9) +"A"+ LetterGood.Substring(10);
                    Pisaccelerator += accelerator;
                }
                
                
            } 

            else if(other.gameObject.CompareTag("D") && DFull!=0) 
            {   DFull-=1;
                LetterGood = LetterGood.Substring(0,2) +"D"+ LetterGood.Substring(3);
                Pisaccelerator += accelerator;
            } 
           
            else if(other.gameObject.CompareTag("K") && KFull!=0) 
            {   KFull-=1;
                if(KFull>0)
                {   
                    LetterGood = LetterGood.Substring(0,3) +"K"+ LetterGood.Substring(4);
                    Pisaccelerator += accelerator;
                }
                else
                {
                    LetterGood = LetterGood.Substring(0,8) +"K"+ LetterGood.Substring(9); 
                    Pisaccelerator += accelerator;
                }
            } 
            
            else if(other.gameObject.CompareTag("O") && OFull!=0) 
            {   OFull-=1;
                if(OFull>0)
                {
                    LetterGood = LetterGood.Substring(0,4) +"O"+ LetterGood.Substring(5);
                    Pisaccelerator += accelerator;
                }
                else
                {
                    LetterGood = LetterGood.Substring(0,11) +"O"+ LetterGood.Substring(12);
                    Pisaccelerator += accelerator;
                }
            } 
            else if(other.gameObject.CompareTag("L") && LFull!=0) 
            {   LFull-=1;
                LetterGood =  LetterGood.Substring(0,6)+"L"+LetterGood.Substring(7);
                Pisaccelerator += accelerator;
            } 
            else if(other.gameObject.CompareTag("U") && UFull!=0) 
            {   UFull-=1;
                LetterGood = LetterGood.Substring(0,7)+"U"+LetterGood.Substring(8);
                Pisaccelerator += accelerator;
            } 
            else if(other.gameObject.CompareTag("C") && CFull!=0) 
            {   CFull-=1;
                if(CFull>0)
                {
                    LetterGood = LetterGood.Substring(0,10)+"C"+LetterGood.Substring(11);
                    Pisaccelerator += accelerator;
                }
                else
                {
                    LetterGood = LetterGood.Substring(0,14)+"C"+LetterGood.Substring(15);
                    Pisaccelerator += accelerator;
                }
            } 
            else if(other.gameObject.CompareTag("V") && VFull!=0) 
            {   VFull-=1;
                LetterGood = LetterGood.Substring(0,12)+"V"+LetterGood.Substring(13);
                Pisaccelerator += accelerator;
            } 
            else if(other.gameObject.CompareTag("I") && IFull!=0) 
            {   IFull-=1;
                LetterGood = LetterGood.Substring(0,13)+"I"+LetterGood.Substring(14);
                Pisaccelerator += accelerator;
            } 

             else
             {
              Lives-=1;
             }

                 
        }
        
        if(Lives<1)
        {
            GameOver = true;
            Destroy(gameObject);
        }
        
        if(progress>10 && SpawnManager.difficultyTrue == 1 )
        {
            GameEnded= true;
            Destroy(gameObject);
        }
        else if (CountOccurrences(LetterGood, '*')==0 && SpawnManager.difficultyTrue == 2)
        {   
            GameEnded= true;
            Destroy(gameObject);
        }
        else if (CountOccurrences(LetterGood, '*')==0 && progress>10)
        {   
            GameEnded= true;
            Destroy(gameObject);
        }

    }
    
    public int CountOccurrences(string str, char ch)
    {
        return str.Split(ch).Length - 1;
    }
}
