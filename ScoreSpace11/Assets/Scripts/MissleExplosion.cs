﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float duration;
    [SerializeField] MissleDamage md;
    public int dmg;
    void Start()
    {
        duration = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().LoseHealth(dmg);
        Instantiate(md);
    }
}
