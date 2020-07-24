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
    private Parallax parallax;
    private float horizontalMax;

    void Start () {

        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        parallax = GameObject.FindGameObjectWithTag("parallax").transform.GetComponent<Parallax>();
        horizontalMax = halfWidth;
        if(transform.position.x < mix + horizontalMax)
        {
            transform.position = new Vector3(mix + horizontalMax, transform.position.y, transform.position.z);
        }

        if (transform.position.x > max + horizontalMax)
        {
            transform.position = new Vector3(max + horizontalMax, transform.position.y, transform.position.z);
        }

        parallax.Reset();

    }

	void Update () {

        Vector3 novaPosicao = new Vector3(player.position.x, player.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);//
        transform.position = novaPosicao;

        transform.position = new Vector3
        (
        Mathf.Clamp(transform.position.x, (mix + horizontalMax), max - horizontalMax),
        transform.position.y,
        transform.position.z
        );
    }
}
