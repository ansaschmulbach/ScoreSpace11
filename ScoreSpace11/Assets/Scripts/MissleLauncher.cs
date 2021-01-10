using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{
    public float min_cooldown;
    public float max_cooldown;
    private float cooldown;
    [SerializeField] Missle missle;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(min_cooldown, max_cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            //fire the missle
            Instantiate(missle);
            cooldown = Random.Range(min_cooldown, max_cooldown);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
