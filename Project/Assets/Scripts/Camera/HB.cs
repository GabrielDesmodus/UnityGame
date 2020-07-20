using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB : MonoBehaviour {

    private float hb = ((Screen.width/Screen.width)*2);  
    private int life;
    private GameObject Player;
    private Player playerScript;
    private SpriteRenderer sprite;

    void Start ()
    {
        Player = GameObject.Find("Player");
        playerScript = Player.GetComponent<Player>();
        sprite = GetComponent<SpriteRenderer>();


    }
	
	void Update ()
    { 
        Vida();
    }


    void Vida()
    {
        life = playerScript.vida;
        if (life != 0)
        {
            transform.localScale = new Vector2((life * hb) / 400, transform.localScale.y);
        } 
    }

    public void Damage(bool active)
    {
        if (active)
        {
            transform.localScale = new Vector2(transform.localScale.x, 1);
            sprite.color = Color.cyan;
        }
        else
        {
            sprite.color = Color.white;
            transform.localScale = new Vector2(transform.localScale.x, 0.5f);
        }
    }
}
