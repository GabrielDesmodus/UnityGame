using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCamera : MonoBehaviour {

    private Camera camera;
    private Transform player;
    public float mix;
    public float max;
    public float miy;
    public float may;
    public float colDepth = 4f;
    public float zPosition = 0f;
    private Vector2 screenSize;
    private Transform topCollider;
    private Transform bottomCollider;
    private Transform leftCollider;
    private Transform rightCollider;
    private Vector3 cameraPos;

    private float horizontalMax;

    void Start () {

        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        //horizontalMin = -halfWidth;
        horizontalMax = halfWidth;

        
    }

	void Update () {

        Vector3 novaPosicao = new Vector3(player.position.x, player.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);//
        transform.position = novaPosicao;

        transform.position = new Vector3
        (
        Mathf.Clamp(transform.position.x, (mix + horizontalMax), max),
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
