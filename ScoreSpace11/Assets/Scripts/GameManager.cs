using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameState gameState = new GameState();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
    void LoadGame()
    {
        
    }

    void LoadTutorial()
    {
        
    }
    public void LoadToLeaderboard()
    {
        SceneManager.LoadScene("leaderboard");
    }

}
