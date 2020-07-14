using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEN2 : MonoBehaviour
{
  
   
   // public GameObject projectileDes;
    private Animator anim;
   




    // Use this for initialization
    void Start()
    {
      
        anim = GameObject.Find("Player").transform.GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, transform.position.y + 1.9f, transform.position.z);
       
        this.GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
        Physics2D.IgnoreLayerCollision(11, 11, true);

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {

        if (colisor.gameObject.tag == "Player")
        {
            

            Player player = colisor.gameObject.GetComponent<Player>();
            player.TakeDamage(10);
            
            if (gameObject.name == "projectile2(Clone)")
            {
                
                Destroy(gameObject);
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }
           // Instantiate(projectileDes, transform.position, transform.rotation);

        }


        if (colisor.gameObject.tag == "Chao")
        {

            if (gameObject.name == "projectile2(Clone)")
            {
                Destroy(gameObject);
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

            }
            //Instantiate(projectileDes, transform.position, transform.rotation);












        }





        }


    }

