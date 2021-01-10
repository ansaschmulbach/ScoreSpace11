using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleTarget : MonoBehaviour
{
    public float countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
