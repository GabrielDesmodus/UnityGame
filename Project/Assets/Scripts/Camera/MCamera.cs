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
    private Vector3 novaPosicao;
    private float halfHeight;
    private float halfWidth;
    private float camera_bigger;
    void Start () {

        camera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Debug.Log(camera.aspect);
        Debug.Log(Screen.width / Screen.height);
        if (camera.aspect <= 1.779556f)
        {
            float value = (1.779557f - camera.aspect)/ 1.779557f;
                
            //camera.orthographicSize = camera.orthographicSize+(camera.orthographicSize * value);
            //camera.aspect = 1.779557f;
        }

        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;

        parallax = GameObject.FindGameObjectWithTag("parallax").transform.GetComponent<Parallax>();
        horizontalMax = halfWidth;
        if(max - mix <= (horizontalMax * 2))
        {

        }
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


        //transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);//
        Debug.Log(max - mix); 
        Debug.Log(horizontalMax); 

        if (max-mix <= (horizontalMax * 2))
        {
            Vector3 novaPosicao = new Vector3(max - ((max-mix)/2), player.position.y, transform.position.z);
            transform.position = novaPosicao;
            Debug.Log("YES");
            
        }
        else
        {
            Debug.Log("NOOOOOO");
            Vector3 novaPosicao = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = novaPosicao;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, (mix + horizontalMax), max - horizontalMax),transform.position.y,transform.position.z);
        }
       

    }
}
