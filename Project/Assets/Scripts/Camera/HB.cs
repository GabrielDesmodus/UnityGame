using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB : MonoBehaviour {

    private float hb = ((Screen.width/Screen.width));  
    private float life;
    private GameObject Player;
    private Player playerScript;
    private SpriteRenderer sprite;

    void Start ()
    {
        //transform.position = new Vector2((Screen.width / 2), transform.position.y);
        Player = GameObject.Find("Player");
        playerScript = Player.GetComponent<Player>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	void Update()
    { 
        Vida();
    }


    void Vida()
    {
        //life = playerScript.vida;
        //if (life != 0)
        //{
        //    transform.localScale = new Vector2(((life/ 100)*2), 2);
        //    sprite.color = Color.white;
        //} 
    }

    public void Damage(bool active)
    {
        life = playerScript.vida;
        if (active)
        {
            transform.localScale = new Vector2(transform.localScale.x + (transform.localScale.x *Time.deltaTime*0.5f), 1);
            sprite.color = Color.cyan;
        }
        else if (life != 0)
        {
            transform.localScale = new Vector2(((life / 100) * 2), 2);
            sprite.color = Color.white;
        }
        //else
        //{

        //    sprite.color = Color.white;
        //    transform.localScale = new Vector2(((life / 100) * 2), 2);
        //}
    }
}
