using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENdmg3 : MonoBehaviour
{

    public GameObject sword_0;
    private int health;
    //private GameObject Ed;
    //private Vector3 dscale;
    //private Quaternion drot;
    //private Vector3 dposition;
    private Animator anim;
    public bool dest;



    // Use this for initialization
    void Start()
    {
        anim = gameObject.transform.GetComponent<Animator>();
        //Ed = GameObject.Find("Ed");
        sword_0 = GameObject.Find("sword_0");
        health = 250;
        //GameObject.Find("death").SetActive(false);

        //dscale = new Vector3(0, 1.5f, 0.0f);
        //drot = new Quaternion(0.02f, 360f, 360f, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Death", health);
        if (dest == true)
        {
            Destroy(this.gameObject);
            Destroy(GameObject.Find("damage"));
        }
        //dposition = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
        if (health < 0)
        {
            //transform.localPosition = Vector3.Lerp(dposition, transform.localPosition, 35 * Time.deltaTime);
            //transform.localScale = Vector3.Lerp(dscale, transform.localScale, 37 * Time.deltaTime);
            //transform.localRotation = Vector3.Lerp(drot, transform.localRotation, 1f * Time.deltaTime);
            //Quaternion.Lerp(transform.localRotation, drot, 1 * Time.deltaTime);
            //GetComponent<Collider>().enabled = false;
            //GameObject.Find("death").SetActive(true);






        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "sword" && dest == false)
        {
            transform.Find("damage").GetComponent<Renderer>().enabled = true;
            health = health - 50;
        }

    }
    void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "sword")
        {
            transform.Find("damage").GetComponent<Renderer>().enabled = false;
        }
    }


}
