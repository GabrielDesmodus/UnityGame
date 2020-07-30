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
        Damage(false);
    }
	
	void Update()
    { 
        
    }

    public void Damage(bool active)
    {
        life = playerScript.vida;
        if (active)
        {
            transform.localScale = new Vector2(transform.localScale.x + (transform.localScale.x *Time.deltaTime*0.2f), transform.localScale.y);
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - (transform.localScale.y * Time.deltaTime * 0.3f));
            Color myColor = new Color();
            ColorUtility.TryParseHtmlString("#FFCF00", out myColor);
            sprite.color = myColor;
        }
        else if (life != 0)
        {
            transform.localScale = new Vector2(((life / 100) * 2), 2);
            sprite.color = Color.white;
        }
    }
}
