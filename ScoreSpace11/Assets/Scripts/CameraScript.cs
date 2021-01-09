using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class CameraScript : MonoBehaviour
{

    private Transform player;
    private Camera camera;
    private Vector3 velocity = Vector3.zero;
    private float dampTime = 0.15f;
    [SerializeField] private Vector2 vectorDelta;
    
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.player = player.transform;
        camera = GetComponent<Camera>();
    }

    
    void Update()
    {
        if (player)
        {
            Vector3 point = camera.WorldToViewportPoint(player.position);
            Vector3 delta = player.position - camera.ViewportToWorldPoint(new
                Vector3(vectorDelta.x, vectorDelta.y, point.z));
            Vector3 dest = this.transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, dest, ref velocity, dampTime);
        }
    }
}
