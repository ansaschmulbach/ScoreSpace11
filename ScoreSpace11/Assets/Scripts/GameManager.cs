using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameState gameState;
    private AudioManager manager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameState = new GameState();
            DontDestroyOnLoad(this.gameObject);
            manager = (AudioManager) Object.FindObjectOfType(typeof(AudioManager));
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
        SceneManager.LoadScene("Field Copy");
        manager.StartGameSound();
    }

    public void LoadTutorial()
    {
        
    }

    public void LoadEnterName()
    {
        SceneManager.LoadScene("EnterName");
    }
    
    public void LoadToLeaderboard()
    {
        SceneManager.LoadScene("leaderboard");
    }

}
