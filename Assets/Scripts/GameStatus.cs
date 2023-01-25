using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStatus : MonoBehaviour
{ 
    /*
     * Created by Kutay Senyigit for Trelans Studio
     * Date: 14/06/2022
     * 
     */

    private Player player;
    
    private int gameStatus;
    private int currentLevel;
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject tapToPlayPanel;
    [SerializeField] private TextMeshProUGUI levelTMP;



    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        OnStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tap to play
        if (gameStatus == 0)
        {
           
        }
        // GameOver
        else if (gameStatus == -1)
        {
            
        }
        // Playing
        else if (gameStatus == 1)
        {
            
        }
       

    }


    public void SetGameOver()
    {
        gameStatus = -1;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void SetWaitingToStart()
    {
        Time.timeScale = 0;
        gameStatus = 0;
    }

    public void SetPlaying()
    {
        gameStatus = 1;
        Time.timeScale = 1;
        ClosePanels();
        player.StartWalk();
     
    }

   
    private void OnStart()
    {
        // Things to do at the begging of the game
        
       SetWaitingToStart();
       _levelManager.LoadInitialLevel();
       currentLevel =   _levelManager.GetCurrentLevel();
       levelTMP.SetText( "Level " + currentLevel );
    }

    private void ClosePanels()
    {
        gameOverPanel.SetActive(false);
        tapToPlayPanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Win()
    {
        player.SetOnFinish(true);
        Debug.Log("WON!");
        winPanel.SetActive(true);
    }
   
}
