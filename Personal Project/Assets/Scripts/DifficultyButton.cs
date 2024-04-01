using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{   private Button button;
    public int difficulty; 
    public SpawnManager SpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        button= GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        SpawnManager = FindObjectOfType<SpawnManager>();  
    }

    void SetDifficulty()
    {
        SpawnManager.StartGame(difficulty);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
