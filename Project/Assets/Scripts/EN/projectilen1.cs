using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilen1 : MonoBehaviour {

    private float wait;
    private Animator anim;




    // Use this for initialization
    void Start () {

        anim = GameObject.Find("Player").transform.GetComponent<Animator>();
        // GameObject Player = GameObject.Find("Player");
        // Player playerScript = Player.GetComponent<Player>();
        // dmg = playerScript.vidaAtual;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);





    }
	
	// Update is called once per frame
	void Update () {
        GameObject Enemy = GameObject.Find("EN");
        GameObject Enemy2 = GameObject.Find("EN2");
        transform.Translate(Vector2.right * 50 * Time.deltaTime);
        Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), Enemy.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), Enemy2.GetComponent<BoxCollider2D>());


    }
    
}
