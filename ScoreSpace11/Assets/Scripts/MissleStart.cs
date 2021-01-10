using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleStart : MonoBehaviour
{
    [SerializeField] Missle missle;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0.05f,0.05f,0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += velocity;
        if(this.transform.position.y > 5)
        {
            Instantiate(missle);
            Destroy(this.gameObject);
        }
    }
}
