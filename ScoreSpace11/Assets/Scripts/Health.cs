using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int maxHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fill;
    [SerializeField] private Gradient gradient;
    private int health;

    void Start()
    {
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

    public void LoseHealth(int amount)
    {
        health = Math.Max(0, health - amount);
        UpdateHealthBar();
        if (health == 0)
        {
            Die();   
        }
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
    }
    
}
