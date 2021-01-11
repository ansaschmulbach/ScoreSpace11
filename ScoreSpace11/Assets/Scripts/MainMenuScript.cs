using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTutorial()
    {
        GameManager.instance.LoadTutorial();
    }
    
    public void LaunchGame()
    {
        GameManager.instance.LoadGame();
    }
    
    public void callLeaderboardTransition()
    {
        GameManager.instance.LoadToLeaderboard();
    }
    public void callTutorialTransition()
    {
        GameManager.instance.LoadTutorial();
    }
}
