using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleDamage : MonoBehaviour
{
    private Transform player;
    private float duration;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        duration = 1;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.position.x, player.position.y + 2, player.position.z);
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
