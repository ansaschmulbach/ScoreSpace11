using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{
    public float min_cooldown;
    public float max_cooldown;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            //fire the missle
            cooldown = Random.Range(min_cooldown, max_cooldown);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
