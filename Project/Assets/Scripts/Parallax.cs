using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Transform cam;
    private float distance;
    private float new_distance;
    private float difference;
    private Vector3 reset_pos;

    // Start is called before the first frame update
    void Start()
    {
        reset_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        distance = cam.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        new_distance= cam.transform.position.x - transform.position.x;
        difference = new_distance - distance;
        transform.position = new Vector3(transform.position.x + (difference*(transform.position.z*0.1f)), transform.position.y, transform.position.z);
        distance = cam.transform.position.x - transform.position.x;
    }

    public void Reset()
    {
        transform.position = new Vector3(-8.5f, transform.position.y, transform.position.z);
        difference = 0;
    }
    
}
