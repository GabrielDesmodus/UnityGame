using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN2dmg2 : MonoBehaviour
{
    public GameObject sword_0;
    private int health;
    private Vector3 dscale;
    private Vector3 dposition;
    private Animator anim;
    public bool dest;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.transform.GetComponent<Animator>();
        sword_0 = GameObject.Find("sword_0");
        health = 250;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Death", health);
        if (dest == true)
        {
            Destroy(this.gameObject);
            Destroy(GameObject.Find("damage2"));
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
        if (colisor.gameObject.tag == "sword")
        {
            transform.Find("damage2").GetComponent<Renderer>().enabled = true;
            health = health - 50;
        }

    }
    void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "sword")
        {
            transform.Find("damage2").GetComponent<Renderer>().enabled = false;
        }
    }
}
