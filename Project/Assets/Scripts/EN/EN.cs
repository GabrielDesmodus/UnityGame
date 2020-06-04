using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN : MonoBehaviour {

    public float velocidade;
    //public bool direcao;
    //public float duracaoDirecao;
    //private float tempoNaDirecao;
    private Animator animator;
    private bool atk;
    //public float tempoParado;
    private Transform player;
    //public Transform target;
    //public int vidaAtualEn;
    public float dist;
    private Vector3 playerDistance;
    private float wait;
    private float Pwait;
    //public bool hit;
    //pubSlic float backwTime;
    public float SetVelocidade;
    //public int health1;
    //public int life;
    //public Vector2 damageForce;
    public int vida;
    private bool death;
    //private bool facingRight = false;
    private Rigidbody2D rb;
    private Transform damageSprite;
    private SpriteRenderer damageSpriteRend;
    public bool canFlip;
    public bool canProjectile;
    public bool canBoundarie;
    public GameObject projectile;
    public float boundarie1, boundarie2; //boundaries made to impede the enemy from falling or getting in unallowed places
    public bool isEN3;

    void Start()
    {
        animator = GetComponent<Animator>();
        damageSprite = this.gameObject.transform.GetChild(0);
        damageSpriteRend = damageSprite.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("walking", true);
        //animator.SetBool("vida", true);
        vida = 100;
        death = false;
    }

    void Update()
    {
        
            Boundarie();
        

        if (canProjectile)
        {
            Projectile();
        }

        if (canFlip)
        {
            Flip();
        }
        
        wait += Time.deltaTime;
        playerDistance = player.transform.position - transform.position;
        dist = Vector3.Distance(player.position, transform.position);
        

        /*if (player.position.x > this.transform.position.x)
        {
            ;
        }
        else
        {
            ;
        }*/

        /*if (velocidade == 0)
        {
            tempoParado += Time.deltaTime;
        }

        if (tempoParado >= 2 && dist >2)
        {
            velocidade = 4f;
        }
        else
        {
            velocidade = 0;
        }*/


        /*if (direcao)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        */

        /*tempoNaDirecao += Time.deltaTime;
        if (tempoNaDirecao >= duracaoDirecao)
        {
            tempoNaDirecao = 0;
            direcao = !direcao;
        }*/


        /*dist = Vector3.Distance(player.position, transform.position);

        wait += Time.deltaTime;

        if (dist < 20 && !animator.GetCurrentAnimatorStateInfo(0).IsName("Death1"))
        {
            if (wait > 2 )
            {
                Instantiate(projectile1, transform.position, transform.rotation);
                wait = 0;
            }
            if (dist < 3.5f)
            {
                velocidade = 0;


                {

                    animator.SetBool("atacou", false);
                }
            }

            else
            {
                velocidade = 2;
                animator.SetBool("atacou", false);
            }
            animator.SetBool("walking", true);
        }

        else
        {
            velocidade = 1;
            animator.SetBool("walking", false);
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            wait = 0;
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Death1"))
        {
            velocidade = 0;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }


        /*backwTime += Time.deltaTime;
        if (backwTime < 4)
        {
            transform.Translate(Vector2.right * -5 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        if (hit == true)
        {
            backwTime = 0;
        }
        else
        {
            backwTime += Time.deltaTime;
        }*/


    }

    private void Projectile()
    {
        Pwait += Time.deltaTime;
        if (death == false && Pwait > 3)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            Pwait = 0;
        }
    }

    private void Flip()
    {
        if (playerDistance.x > 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (playerDistance.x < 0.5f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void Boundarie()
    {
        if (transform.position.x > boundarie1 && transform.position.x < boundarie2 && dist > 3) // if the enemy is not in the boundaries it keeps moving
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        if (/*transform.position.x <= boundarie1&& */ dist > 3){ // if the enemy is on the boundaries it only moves if he looks at the right side
            if (transform.eulerAngles.y == 0)
            {
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            }
        }
        if (/*transform.position.x >= boundarie2&& */ dist > 3){
            // if the enemy is on the boundaries it only moves if he is looks at the left side side
            if (transform.eulerAngles.y == 180)
            {
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        Player cplayer = colisor.gameObject.GetComponent<Player>();
        if (cplayer != null)
        {
            Player player = colisor.gameObject.GetComponent<Player>();
            player.TakeDamage(10);
           
            
        }
        else if(colisor.gameObject.tag == "Sword")
        {
            Player player = colisor.gameObject.GetComponent<Player>();
            player.TakeDamage(0);
        }
        
    }

    public void TakeDamage(int damage)
    {
        vida -= (damage);
 
        if (vida <= 0 && death == false)
        {
            if (isEN3 == false)
            {
                //animator.SetBool("vida", false);
                death = true;
                animator.Play("Death1");
                var clipInfo = animator.GetCurrentAnimatorStateInfo(0);
                Destroy(this.gameObject, clipInfo.length);
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
           }
            else
            {
                death = true;
                animator.Play("Death1");               
                Destroy(this.gameObject, 0.25f);
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            }
            
        }
    }
    public void DamageSpriteF (bool DMF)
    {
        damageSpriteRend.enabled = DMF;
    }






}
