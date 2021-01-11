using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDayCanvas : MonoBehaviour
{
    private Canvas canvas;
    private FadeCanvas fade;
    private GameState gameState;
    [SerializeField] TextMeshProUGUI text; //Night's Over!
    [SerializeField] TextMeshProUGUI cowR; //How many cows did we rescue?
    [SerializeField] TextMeshProUGUI milkR; // Score
    [SerializeField] TextMeshProUGUI moneyR; //Bank
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.GetComponent<CanvasGroup>().alpha = 0;
        canvas.enabled = true;
        fade = GetComponent<FadeCanvas>();
        fade.FadePanel();
        gameState = GameManager.instance.gameState;
        cowR.text = "Cows rescued: " + gameState.cow;
        milkR.text = "Score: " + gameState.score;
        moneyR.text = "Milk Extracted:  " + gameState.money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transition()
    {
        //Move to next canvas
    }

}
