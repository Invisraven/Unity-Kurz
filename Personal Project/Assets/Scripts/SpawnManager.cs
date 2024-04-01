using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject player;

    public GameObject arrows;

    private float zSpawn =12.0f;
    private float xSpawnRange= 23.0f;
    private float ySpawn =0.0f;
    private float SpawnTime = 1.0f;
    private float startDelay = 1.0f;
    public PlayerController PlayerController;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Meno;
    public TextMeshProUGUI Postupka;
    public TextMeshProUGUI LivesText;
    public Button Restart;
    public Button Easy;
    public Button Medium;
    public Button Hard;
    public bool GameStarted = false;
    public int difficultyTrue;
    private int lives;
    private int progress=0;
    private int Ostava;
   
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStarted)
        {if(PlayerController.GameOver)
        {
            gameOverText.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            Postupka.gameObject.SetActive(false);
            Meno.gameObject.SetActive(false);
            LivesText.gameObject.SetActive(false);
            arrows.gameObject.SetActive(false);
        }
        if(PlayerController.GameEnded)
        {
            gameOverText.text = "Super Radko, VYHRAL SI!!! Level " + difficultyTrue ;
            gameOverText.color = Color.green;
            gameOverText.gameObject.SetActive(true);
            Restart.gameObject.SetActive(true);
            arrows.gameObject.SetActive(false);
        }

         if(PlayerController.Lives!=lives)
         {  

            lives= PlayerController.Lives;
            LivesText.text = "Moznych chyb: " + lives;
         }
         
         if(PlayerController.CountOccurrences(PlayerController.LetterGood, '*')!=Ostava)
         {  
            Ostava=PlayerController.CountOccurrences(PlayerController.LetterGood, '*');
            Meno.text = PlayerController.LetterGood;
         }

         if(PlayerController.progress!=1+progress)
         {  
            progress= PlayerController.progress-1;
            int cislo=progress-1;
            if(cislo ==0)
            {
                Postupka.text = Postupka.text + cislo;
            }
            else
            {
                Postupka.text = Postupka.text + ", " + cislo;
            }
            
         }

        }
        
    }

    void SpawnSigns()
    {   
        if(!PlayerController.GameOver && !PlayerController.GameEnded)
        {   int randomIndex;
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            if(difficultyTrue==1)
            {
                randomIndex = Random.Range(0, 11);
            }
            else if(difficultyTrue==2)
            {
                randomIndex = Random.Range(11, spawns.Length);
            }
            else
            {   
                randomIndex = Random.Range(0, 11);
                randomIndex = Random.Range(0, spawns.Length);  
            }
            
            Vector3 spawnPos = new Vector3(randomX, ySpawn, zSpawn);
            Instantiate(spawns[randomIndex], spawnPos, spawns[randomIndex].gameObject.transform.rotation);
        }    
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {   Title.gameObject.SetActive(false);
        Easy.gameObject.SetActive(false);
        Medium.gameObject.SetActive(false);
        Hard.gameObject.SetActive(false);
        LivesText.gameObject.SetActive(true);
        arrows.gameObject.SetActive(true);
        InvokeRepeating("SpawnSigns", startDelay, SpawnTime*PlayerController.progress);
        Instantiate(player, new Vector3(0, 0, 0), player.gameObject.transform.rotation);
        PlayerController = FindObjectOfType<PlayerController>();  
        GameStarted = true;
        difficultyTrue=difficulty;
        Ostava=PlayerController.CountOccurrences(PlayerController.LetterGood, '*');
        if(difficultyTrue==1)
            {   
                Postupka.gameObject.SetActive(true);
                Postupka.text = "Nazbierane: ";
            }
            else if(difficultyTrue==2)
            {
                Meno.gameObject.SetActive(true);
                Meno.text = PlayerController.LetterGood;
            }
            else
            {
                Postupka.gameObject.SetActive(true);
                Postupka.text = "Nazbierane: ";
                Meno.gameObject.SetActive(true);
                Meno.text = PlayerController.LetterGood;
            }
        
    }
}
