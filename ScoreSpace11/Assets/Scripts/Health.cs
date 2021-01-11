using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int maxHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fill;
    [SerializeField] private Gradient gradient;
    private int health;
    public TextMeshProUGUI healthTxt;
    public FadeCanvas healthBox;

    void Start()
    {
        healthBox = (FadeCanvas) GameObject.Find("dmgBox").GetComponent<FadeCanvas>();
        healthTxt = GameObject.Find("dmgBox").GetComponent<TextMeshProUGUI>();
        health = maxHealth;
        if (healthSlider)
        {
            healthSlider.maxValue = maxHealth;
            UpdateHealthBar();
        }
    }

    private void Update()
    {
    }

    public void Multiply(float multiplier)
    {
        maxHealth = (int) (maxHealth * multiplier);
        health = (int) (health * multiplier);
        healthSlider.maxValue = maxHealth;
        UpdateHealthBar();
    }

    public void LoseHealth(int amount)
    {
        health = Math.Max(0, health - amount);
        UpdateHealthBar();
        if (this.gameObject.CompareTag("Player") && amount > 0)
        {
            StartCoroutine(DisplayHealthLoss(amount));
        }

        if (health == 0)
        {
            Die();   
        }
    }

    public IEnumerator DisplayHealthLoss(int pts)
    {
        
        healthBox.FadePanel();
        healthTxt.text = "- " + pts + " hp";
        yield return new WaitForSeconds(1);
        healthBox.FadePanel();
        yield return null;
    }

    public void GainHealth(int amount)
    {
        health = Math.Min(maxHealth, health + amount);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthSlider.value = health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    void Die()
    {
        Destroy(this.gameObject);
        if (this.CompareTag("Player"))
        {
            GameManager.instance.LoadEnterName();
        }
    }
    
}
