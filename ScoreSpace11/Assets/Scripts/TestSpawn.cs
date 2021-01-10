using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public SpawnDestroy spwn;
    void Start()
    {
        spwn.SpawnAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
