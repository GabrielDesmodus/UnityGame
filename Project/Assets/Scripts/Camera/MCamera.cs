using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCamera : MonoBehaviour {

    private Transform player;
    public float mix;
    public float max;
    public float miy;
    public float may;

    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(Screen.width);

    }

	void Update () {

        Vector3 novaPosicao = new Vector3(player.position.x, player.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);//
        transform.position = novaPosicao;

        transform.position = new Vector3
        (
        Mathf.Clamp(transform.position.x, mix, max),
        transform.position.y,
        transform.position.z
        );

        if (transform.position.y > may)
        {
            transform.position = new Vector3(transform.position.x, may, transform.position.z);
        }

        if (transform.position.y < miy)
        {
            transform.position = new Vector3(transform.position.x, miy, transform.position.z);
        }
    }
}
