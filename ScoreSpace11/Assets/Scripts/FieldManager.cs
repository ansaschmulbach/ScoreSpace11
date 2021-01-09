using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{

    [SerializeField] private float nightLength;
    private float nightTimer;

    void Start()
    {
        nightTimer = nightLength;
    }

    void Update()
    {
        
    }
}
