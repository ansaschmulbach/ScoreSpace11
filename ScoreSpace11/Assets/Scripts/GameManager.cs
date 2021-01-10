using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameState gameState;
    public AudioManager manager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameState = new GameState();
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        
    }
    
    void Update()
    {
        
    }
    public void LoadGame()
    {
        manager.StopBgSound();
        SceneManager.LoadScene("Field");
    }

    public void LoadTutorial()
    {
        
    }
    public void LoadToLeaderboard()
    {
        SceneManager.LoadScene("leaderboard");
    }

}
