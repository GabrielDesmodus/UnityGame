using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB : MonoBehaviour {

    public bool takeDamage;
    private float hb = ((Screen.width/Screen.width)*2);   
    private Transform player;
    private int life;


    void Start ()
    {
       
    }
	
	void Update ()
    {
        
        Vida();

    }


    void Vida()
    {
        GameObject Player = GameObject.Find("Player");
        Player playerScript = Player.GetComponent<Player>();
        life = playerScript.vida;
        transform.localScale = new Vector2((life*hb)/400,0.5f);
    }
}
