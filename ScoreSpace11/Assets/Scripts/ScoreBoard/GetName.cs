using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetName : MonoBehaviour
{
    public ScoreBoard board;
    public TMP_InputField iField;
    private string myName;
    
    public void storeString()
    {
        myName = iField.text;
    }

    // Update is called once per frame
    void Update()
    {
        this.storeString();
    }

    public void uploadScores()
    {
        board.AddNewHighscore(this.myName, GameManager.instance.gameState.score);
    }
}
