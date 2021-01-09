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
    private int health;

    void Start()
    {
        health = maxHealth;
        if (healthSlider)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    private void Update()
    {
    }

    void LoseHealth(int amount)
    {
        health = Math.Max(0, health - amount);
        UpdateHealthBar();
        if (health == 0)
        {
            Die();   
        }
    }

    void GainHealth(int amount)
    {
        health = Math.Min(maxHealth, health + amount);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthSlider.value = health;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
    
}
