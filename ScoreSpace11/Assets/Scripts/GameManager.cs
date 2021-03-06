﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameState gameState;
    private AudioManager manager;
    public SaveManager sm;
    //public int personal_best = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameState = new GameState();
            sm = new SaveManager();
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
        SceneManager.LoadScene("Field");
        manager.StartGameSound();
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadEnterName()
    {
        //instance.sm.SaveRecord();
        SceneManager.LoadScene("EnterName");
    }
    
    public void LoadToLeaderboard()
    {
        SceneManager.LoadScene("leaderboard");
    }
    public void LoadToMain()
    {
        instance = new GameManager();
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
