using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPR4 : MonoBehaviour
{

    private bool col;
    private Transform player;
    public float po1;
    public float po2;
    public bool test;
    private float dist;
    public float show;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(player.position, transform.position);
        show = dist;


        if (dist < 2 && Input.GetButtonDown("Fire4"))
        {
            player.transform.position = new Vector3(po1, po2, player.transform.position.z);
            test = true;
            dist = 0;


        }

    }


}
