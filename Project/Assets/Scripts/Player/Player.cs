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
    //private SpriteRenderer opacity;
   
    public float boundarie1, boundarie2, boundarie3, boundarie4;
    public LayerMask layer;
    private float waitToJump;
    public GameObject Enemy;
    public GameObject Enemy2;
    private bool endOfCombo;

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
        Enemy = GameObject.Find("EN");
        Enemy2 = GameObject.Find("EN2");
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        iFrame += Time.deltaTime;

        if (iFrame < 2)
        {
            var opacity = GetComponent<SpriteRenderer>().material.color;
            sprite.color = Color.red;
            opacity.a = 0.5f;
            sprite.color = opacity;
            Physics2D.IgnoreLayerCollision(0, 11, true);

        }
        else
        {
            Physics2D.IgnoreLayerCollision(0, 11, false);
            sprite.color = Color.white;

        }

        lastClickedTime += Time.deltaTime;
        Attack();
        Movimentacao();
        GroundCheck();
        waitToJump += Time.deltaTime;
    }
   

    void GroundCheck()
    {
        estaNoChao = Physics2D.OverlapCircle(chaoVerificador.position, 3, layer);
    }

    void Attack()
    {

        if(lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", false);
            lastClickedTime = 0;
        }
        
        if(Input.GetButtonDown("Fire1") && lastClickedTime < maxComboDelay && lastClickedTime > 0.5f && noOfClicks==0)
        {
            animator.SetBool("Attack1", true);
            lastClickedTime = 0;
            noOfClicks = 1;
            
        }
        if (Input.GetButtonDown("Fire1") && lastClickedTime < maxComboDelay && lastClickedTime > 0.4f && noOfClicks==1)
        {
            Debug.Log("2");
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", true);
            lastClickedTime = 0;
            noOfClicks = 2;
        }
        if (Input.GetButtonDown("Fire1") && lastClickedTime < maxComboDelay && lastClickedTime > 0.4f && noOfClicks == 2)
        {
            Debug.Log("2");
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", true);
            lastClickedTime = 0;
            noOfClicks = 3;
        }
        if (lastClickedTime < maxComboDelay && lastClickedTime > 0.4f && noOfClicks == 3)
        {
            animator.SetBool("Attack3", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack1", false);
            lastClickedTime = 0;
            noOfClicks = 0;
        }


        //if (lastClickedTime > maxComboDelay)
        //{
        //    noOfClicks = 0;
        //    animator.SetBool("Attack1", false);
        //    animator.SetBool("Attack2", false);
        //    animator.SetBool("AttackX1", false);
        //    animator.SetBool("Attack3", false);
        //    lastClickedTime = 0;
        //}

        //if (endOfCombo==true || lastClickedTime >0.5f)
        //{
        //    animator.SetBool("Attack3", false);

        //}

        //if (noOfClicks == 0)
        //{
        //    click1 = true;
        //    clickx1 = true;
        //    /*click2 = false;**/
        //    click3 = false;
        //}

        //else
        //{
        //    click1 = false;
        //    clickx1 = false;
        //}
        //if (noOfClicks == 1)
        //{
        //    click2 = true;
        //    click1 = false;
        //    click3 = false;
        //}
        //else
        //{
        //    click2 = false;
        //}

        //if (noOfClicks == 2)
        //{
        //    click3 = true;
        //    click1 = false;
        //    /*click2 = false;*/
        //}
        //else
        //{
        //    click3 = false;
        //}

        //if (Input.GetButtonDown("Fire1") && click1 == true /*&& Time.time > tP*/ && lastClickedTime > 0.7 || endOfCombo==true)
        //{
        //    lastClickedTime = 0;
        //    noOfClicks = 1;
        //    noOfClickspe = 1;
        //    animator.SetBool("Attack1", true);
        //    endOfCombo = false;
        //}
        //else
        //{
        //    animator.SetBool("Attack1", false);
        //}

        //if (Input.GetButtonDown("Fire1") && click2 == true && lastClickedTime < maxComboDelay && lastClickedTime > 0.5f)
        //{
        //    lastClickedTime = 0;
        //    noOfClicks = 2;
        //    noOfClickspe = 2;
        //    animator.SetBool("Attack2", true);
        //}
        //else
        //{
        //    /*animator.SetBool("Attack2", false);*/

        //}

        //if (Input.GetButtonDown("Fire1") && click3 == true && lastClickedTime <= maxComboDelay /*&& Time.time > tP*/ && lastClickedTime > 0.5f)
        //{
        //    Debug.Log("???");

        //    animator.SetBool("Attack3", true);

        //    noOfClicks = 0;

        //    lastClickedTime = 0;
        //    endOfCombo = true;
        //}

        //if (Input.GetButtonDown("Fire2") && Time.time > tP)
        //{
        //    animator.SetBool("AttackX1", true);
        //    tP = Time.time + 1.35f;
        //}
        //if (Input.GetButton("Fire3"))
        //{
        //    animator.SetBool("shield", true);
        //    /*sword_0.GetComponent<CapsuleCollider2D>().isTrigger = false;*/
        //    velocidade = 0;
        //}
        //else
        //{
        //    animator.SetBool("shield", false);
        //    Physics2D.IgnoreCollision(sword_0.GetComponent<CapsuleCollider2D>(), cc1.GetComponent<BoxCollider2D>());
        //    velocidade = 14;
        //    /*sword_0.GetComponent<CapsuleCollider2D>().isTrigger = true;*/
        //}
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

    //void Movimentacao()
    //{
    //    var rigidbody2D = GetComponent<Rigidbody2D>();
    //    rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, 80);
    //    if (!estaNoChao)
    //    {
    //        rigidbody2D.gravityScale = 40;

    //    }
    //    else
    //    {
    //        rigidbody2D.gravityScale = 5;

    //    }

    //    if (Input.GetAxisRaw("Horizontal") > 0 && iFrame > 0.25f && waitToJump > 0.25f && estaNoChao)
    //    {
    //        if (estaNoChao)
    //        {
    //            transform.eulerAngles = new Vector2(0, 0);

    //            rigidbody2D.MovePosition(transform.position + transform.right * 16 * Time.fixedDeltaTime);

    //        }
    //    }
    //    if (waitToJump > 0.25f && Input.GetAxisRaw("Horizontal") > 0 && iFrame > 0.25f && Input.GetButtonDown("Jump") && estaNoChao)
    //    {
    //        waitToJump = 0;
    //        transform.eulerAngles = new Vector2(0, 0);
    //        rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, 120);
    //        rigidbody2D.velocity = rigidbody2D.velocity + Vector2.up * 80;
    //        rigidbody2D.velocity = rigidbody2D.velocity + Vector2.right * 30;
    //        rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, 80);


    //    }

    //    if (Input.GetAxisRaw("Horizontal") < 0 && iFrame > 0.25f && waitToJump>0.25f)
    //    {
    //        if (estaNoChao)
    //        {
    //            transform.eulerAngles = new Vector2(0, 180);

    //            rigidbody2D.MovePosition(transform.position + transform.right * 16 * Time.fixedDeltaTime);

    //        }
    //    }
    //    if (waitToJump >0.25f && Input.GetAxisRaw("Horizontal") < 0 && iFrame > 0.25f && Input.GetButtonDown("Jump") && estaNoChao)
    //    {
    //        waitToJump =0;
    //        transform.eulerAngles = new Vector2(0, 180);
    //        rigidbody2D.velocity = rigidbody2D.velocity + Vector2.up * 80;
    //        rigidbody2D.velocity = rigidbody2D.velocity + Vector2.left * 30;


    //    }
    //    else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetButtonDown("Jump") && estaNoChao && iFrame > 1)
    //    {

    //        rigidbody2D.velocity = rigidbody2D.velocity + Vector2.up * 60;
    //        //rigidbody2D.AddForce(transform.up * 7000);
    //    }






    //    //estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
    //    animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    //    //estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
    //    animator.SetBool("chao", estaNoChao);
    //}




    //The enemy calls this function to deal damage to the player
    void Movimentacao()
    {
        var rigidbody2D = GetComponent<Rigidbody2D>();

        if (!estaNoChao)
        {
            rigidbody2D.gravityScale +=1;
            velocidade = 24;

        }
        else
        {
            rigidbody2D.gravityScale = 1;
            velocidade = 14;
        }
        if (Input.GetAxisRaw("Horizontal") > 0 && iFrame > 0.25f)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && iFrame > 0.25f)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetButtonDown("Jump") && estaNoChao && iFrame > 1)
        {
            
            rigidbody2D.AddForce(transform.up * forcaPulo);
        }

        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetBool("chao", estaNoChao);
    }
    public void TakeDamage(int damage)
    {
        if (iFrame > 1.5f)
        {
            
            iFrame = 0;
            sprite.color = new Color(0.5283019f, 0f, 0f, 1f);
            vida -= (damage);
            if (vida < 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

}