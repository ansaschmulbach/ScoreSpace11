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
    private float timer;
    private int index;
    private UpgradeScreen upgradeScreen;
    [SerializeField] TextMeshProUGUI text; //Night's Over!
    [SerializeField] TextMeshProUGUI cowR; //How many cows did we rescue?
    [SerializeField] TextMeshProUGUI milkR; // Score
    [SerializeField] TextMeshProUGUI moneyR; //Bank
    [SerializeField] Image headline;
    [SerializeField] Sprite[] newpapers;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.GetComponent<CanvasGroup>().alpha = 0;
        canvas.enabled = true;
        upgradeScreen = FindObjectOfType<UpgradeScreen>();
        fade = GetComponent<FadeCanvas>();
        headline.rectTransform.localPosition = new Vector3(0,-500,0);
        //fade.FadePanel();
        gameState = GameManager.instance.gameState;
        headline.enabled = true;
        velocity = new Vector3(0,16f,0);
        transitioning = false;
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0 && transitioning)
        {
            if(headline.rectTransform.localPosition.y < 0)
            {
                headline.rectTransform.localPosition += velocity;
                velocity = new Vector3(0,velocity.y - Time.deltaTime*18f, 0);
                if(velocity.y < 0)
                {
                    velocity.y = 0.05f;
                }
            }
            timer -= Time.deltaTime;
        }
        else
        {
            if(transitioning)
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
        headline.rectTransform.localPosition = new Vector3(0,-500,0);
        velocity = new Vector3(0,16f,0);
        index++;
        headline.sprite = newpapers[index];
    }

    public void showResults()
    {
        Debug.Log("hi");
        fade.FadePanel();
        cowR.text = "Cows rescued: " + gameState.cow;
        milkR.text = "Score: " + gameState.score;
        moneyR.text = "Milk Extracted:  " + gameState.money;
    }

    public void transition()
    {
        transitioning = true;
        timer = 10;
    }
}
