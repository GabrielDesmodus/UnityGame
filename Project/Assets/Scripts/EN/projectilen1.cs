using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilen1 : MonoBehaviour {

    private float wait;
    private Animator anim;
    private Player player;


    // Use this for initialization
    void Start () {

        anim = GameObject.Find("Player").transform.GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * 50 * Time.deltaTime);
        Physics2D.IgnoreLayerCollision(11, 11, true);

    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        player = colisor.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(10);
            Destroy(this.gameObject);
        }
        else if (colisor.gameObject.tag == "Sword")
        {

            return;
        }

    }
}
