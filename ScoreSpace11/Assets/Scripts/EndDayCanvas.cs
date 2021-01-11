using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDayCanvas : MonoBehaviour
{
    public Canvas canvas;
    private FadeCanvas fade;
    private GameState gameState;
    private Vector3 velocity;
    private bool transitioning;
    private UpgradeScreen upgradeScreen;
    [SerializeField] TextMeshProUGUI text; //Night's Over!
    [SerializeField] TextMeshProUGUI cowR; //How many cows did we rescue?
    [SerializeField] TextMeshProUGUI milkR; // Score
    [SerializeField] TextMeshProUGUI moneyR; //Bank
    [SerializeField] Image headline;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.GetComponent<CanvasGroup>().alpha = 0;
        canvas.enabled = true;
        upgradeScreen = FindObjectOfType<UpgradeScreen>();
        fade = GetComponent<FadeCanvas>();
        headline.transform.position = new Vector3(500,-320,0);
        //fade.FadePanel();
        gameState = GameManager.instance.gameState;
        headline.enabled = true;
        velocity = new Vector3(0,3,0);
        transitioning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transitioning)
        {
            if(headline.transform.position.y < 300)
            {
                headline.transform.position += velocity;
            }
            else
            {
                //fade.FadePanel();
                fade.isFaded = true;
                canvas.GetComponent<CanvasGroup>().alpha = 0;
                canvas.enabled = false;
                upgradeScreen.OpenUpgradeScreen();
                transitioning = false;
            }
        }
    }

    public void reset()
    {
        transitioning = false;
        headline.transform.position = new Vector3(500,-320,0);
    }

    public void showResults()
    {
        cowR.text = "Cows rescued: " + gameState.cow;
        milkR.text = "Score: " + gameState.score;
        moneyR.text = "Milk Extracted:  " + gameState.money;
        fade.FadePanel();
    }

    public void transition()
    {
        transitioning = true;
    }
}
