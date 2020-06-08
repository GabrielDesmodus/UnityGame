using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    public float forcaPulo;
    public bool estaNoChao;
    public Transform chaoVerificador;
    public Transform spritePlayer;
    private Animator animator;
    public int maxVida;
    public int vida;
    public int noOfClicks;
    public float lastClickedTime;
    public float maxComboDelay;
    private bool click1;
    private bool click2;
    private bool click3;
    private bool clickx1;
    private int noOfClickspe;
    private float tP;
    public GameObject sword_0;
    public GameObject cc;
    public BoxCollider2D cc1;
    private bool atk;
    private int dmg;
    private Transform enemy;
    private int dL; //Damage inflicted
    private Transform endMarker;
    private Transform lastMarker;
    public float iFrame; //Iframe time
    public float force;
    private float throwback;
    private SpriteRenderer sprite;
    public float boundarie1, boundarie2, boundarie3, boundarie4;
    public float heightthing, groundthing;
    public LayerMask layer;
    private float wait;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = spritePlayer.GetComponent<Animator>();
        vida = maxVida;
        noOfClicks = 0;
        tP = 0;
        sword_0 = GameObject.Find("sword_0");
        cc = GameObject.FindGameObjectWithTag("Chao");
        iFrame = 2;
    }

    void Update()
    {
        iFrame += Time.deltaTime;

        //if(iFrame < 5.5f)
        //{
        //    sprite.color = Color.red;
        //    GameObject Enemy = GameObject.Find("EN");
        //    GameObject Enemy2 = GameObject.Find("EN2");
        //    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), Enemy.GetComponent<BoxCollider2D>());
        //    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), Enemy2.GetComponent<BoxCollider2D>());
        //}
        //else
        //{
        //    sprite.color = Color.white;
        //}
       
        lastClickedTime += Time.deltaTime;
        Attack();
        Movimentacao();
        GroundCheck();
        wait += Time.deltaTime;
    }

    void GroundCheck()
    {
        estaNoChao = Physics2D.OverlapCircle(chaoVerificador.position, 3, layer);


    }

    void Attack()
    {

        if (lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("AttackX1", false);
            animator.SetBool("Attack3", false);
            lastClickedTime = 0;
        }

        if (noOfClicks == 0)
        {
            click1 = true;
            clickx1 = true;
            /*click2 = false;**/
            click3 = false;
        }

        else
        {
            click1 = false;
            clickx1 = false;
        }
        if (noOfClicks == 1)
        {
            click2 = true;
            click1 = false;
            click3 = false;
        }
        else
        {
            click2 = false;
        }

        if (noOfClicks == 2)
        {
            click3 = true;
            click1 = false;
            /*click2 = false;*/
        }
        else
        {
            click3 = false;
        }

        if (Input.GetButtonDown("Fire1") && click1 == true && Time.time > tP)
        {
            lastClickedTime = 0;
            noOfClicks = 1;
            noOfClickspe = 1;
            animator.SetBool("Attack1", true);
        }
        else
        {
            animator.SetBool("Attack1", false);
        }

        if (Input.GetButtonDown("Fire1") && click2 == true && lastClickedTime < maxComboDelay)
        {
            lastClickedTime = 0;
            noOfClicks = 2;
            noOfClickspe = 2;
            animator.SetBool("Attack2", true);
        }
        else
        {
            /*animator.SetBool("Attack2", false);*/

        }

        if (Input.GetButtonDown("Fire1") && click3 == true && lastClickedTime <= maxComboDelay && Time.time > tP)
        {
            animator.SetBool("Attack3", true);
            noOfClicks = 0;
            tP = Time.time + 1;
        }

        if (Input.GetButtonDown("Fire2") && Time.time > tP)
        {
            animator.SetBool("AttackX1", true);
            tP = Time.time + 1.35f;
        }
        if (Input.GetButton("Fire3"))
        {
            animator.SetBool("shield", true);
            /*sword_0.GetComponent<CapsuleCollider2D>().isTrigger = false;*/
            velocidade = 0;
        }
        else
        {
            animator.SetBool("shield", false);
            Physics2D.IgnoreCollision(sword_0.GetComponent<CapsuleCollider2D>(), cc1.GetComponent<BoxCollider2D>());
            velocidade = 14;
            /*sword_0.GetComponent<CapsuleCollider2D>().isTrigger = true;*/
        }
        /*else
         {
             animator.SetBool("AttackX1", false);
         }

         if (Input.GetButtonDown("Fire2"))
         {

             animator.SetBool("ComboXY", true);

         }
         else
         {
             animator.SetBool("ComboXY", false);
         }

         if (Input.GetButtonDown("Fire2") && noOfClickspe == 2)
         {

             animator.SetBool("ComboXXY", true); 
         }
         else
         {
             animator.SetBool("ComboXXY", false);
         }*/
    }

    void Movimentacao()
    {
        var rigidbody2D = GetComponent<Rigidbody2D>();

        if (!estaNoChao)
        {
            rigidbody2D.gravityScale = 40;
        }
        else
        {
            rigidbody2D.gravityScale = 5;
        }

        if (Input.GetAxisRaw("Horizontal") > 0 && iFrame > 0.25f && wait > 0.5f)
        {
            if (estaNoChao)
            {
                transform.eulerAngles = new Vector2(0, 0);

                rigidbody2D.MovePosition(transform.position + transform.right * 16 * Time.fixedDeltaTime);

            }
        }
        if (wait > 0.75f && Input.GetAxisRaw("Horizontal") > 0 && iFrame > 0.25f && Input.GetButtonDown("Jump"))
        {
            wait = 0;
            transform.eulerAngles = new Vector2(0, 0);
            rigidbody2D.velocity = rigidbody2D.velocity + Vector2.up * 60;
            rigidbody2D.velocity = rigidbody2D.velocity + Vector2.right * 20;


        }

        if (Input.GetAxisRaw("Horizontal") < 0 && iFrame > 0.25f && wait>0.5f)
        {
            if (estaNoChao)
            {
                transform.eulerAngles = new Vector2(0, 180);

                rigidbody2D.MovePosition(transform.position + transform.right * 16 * Time.fixedDeltaTime);

            }
        }
        if (wait >0.75f && Input.GetAxisRaw("Horizontal") < 0 && iFrame > 0.25f && Input.GetButtonDown("Jump"))
        {
            wait =0;
            transform.eulerAngles = new Vector2(0, 180);
            rigidbody2D.velocity = rigidbody2D.velocity + Vector2.up * 60;
            rigidbody2D.velocity = rigidbody2D.velocity + Vector2.left * 20;
            

        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetButtonDown("Jump") && estaNoChao && iFrame > 1)
        {
            Debug.Log("AAAA");
            rigidbody2D.velocity = rigidbody2D.velocity + Vector2.up * 60;
            //rigidbody2D.AddForce(transform.up * 7000);
        }
        

       

        

        //estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        //estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetBool("chao", estaNoChao);
    }




    //The enemy calls this function to deal damage to the player
    public void TakeDamage(int damage)
    {
        if (iFrame > 1.5f)
        {
            
            iFrame = 0;
            //wait = 0;
            sprite.color = new Color(0.5283019f, 0f, 0f, 1f);
            vida -= (damage);
            if (vida < 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

}