using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    public float forcaPulo;
    private bool estaNoChao;
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
    //private bool hit;
    private Transform endMarker;
    private Transform lastMarker;
    public float wait;
    public float dWait; //Iframe time
    public float force;
    private float throwback;
    private SpriteRenderer sprite;
    public float boundarie1, boundarie2, boundarie3, boundarie4;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = spritePlayer.GetComponent<Animator>();
        vida = maxVida;
        noOfClicks = 0;
        tP = 0;
        sword_0 = GameObject.Find("sword_0");
        cc = GameObject.FindGameObjectWithTag("Chao");

        /*endMarker = enemy.position.x - 10;
        lastMarker = 1;*/

        wait = 3;
    }

    void Update()
    {
        dWait += Time.deltaTime;
        //if (dWait < 1.5f)
        //{
        //    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>());
        ////    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<CapsuleCollider2D>());
        ////    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<CircleCollider2D>());
        ////    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<EdgeCollider2D>());
        ////    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<PolygonCollider2D>());
        //}

        //if (dWait > 1.5f)
        //{
        //    Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>(), false);
        ////   // Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<CapsuleCollider2D>(), false);
        ////    //Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<CircleCollider2D>(), false);
        ////   // Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<EdgeCollider2D>(), false);
        ////   // Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<PolygonCollider2D>(), false);
        //}

        if (wait > 1.5f)
        {
            sprite.color = Color.white;
        }
        /*if (hit)
        {
            Vector3.LerpUnclamped(enemy.position.x, endMarker, 2); 
        }
        */

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("atkSword"))
        {
            dL = 45;
            throwback = -1000;
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("atkSword2"))
        {
            dL = 100;
            throwback = -1000;
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("atkSword3"))
        {
            dL = 200;
            throwback = -3000;
        }

       
        lastClickedTime += Time.deltaTime;
        Attack();
        Movimentacao();

        //GameObject Enemy = GameObject.Find("EN");
        //EN enemyScript = Enemy.GetComponent<EN>();
        //enemyScript.vidaAtualEn = dmg;
        //hit = enemyScript.hit;

        wait += Time.deltaTime;

        //if (hit == true)
       // {
          //  wait = 0;
       // }
        
      //  var rigid2d = GetComponent<Rigidbody2D>();
        /*if (rigid2d.velocity.magnitude > force && wait <1)
        {
            rigid2d.velocity = rigid2d.velocity.normalized * force;
        }*/
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

        if (Input.GetButtonDown("Fire1") && click3 == true && lastClickedTime <= maxComboDelay && Time.time >tP)
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
        if (Input.GetAxisRaw("Horizontal") > 0 && wait >0.25f)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && wait> 0.25f)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetButtonDown("Jump") && estaNoChao && wait >1)
        {
            var rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(transform.up * forcaPulo);
        }

        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetBool("chao", estaNoChao);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Enemy")
        {
            
            
            //dmg = dmg - dL;
            //enemy.GetComponent<Rigidbody2D>().AddForce(transform.right * throwback);
            /*Destroy(colisor.gameObject);*/
        }
    }

    public void TakeDamage(int damage)
    {
        if (dWait > 1.5f)
        {
            if (transform.position.x - boundarie1 > 5 && transform.position.x - boundarie2 < -5)
            {

                transform.Translate(Vector2.right * -400 * Time.deltaTime);
                transform.Translate(Vector2.up * 200 * Time.deltaTime);
            }
            else if (transform.position.x - boundarie1 < 2)
            {
                if (transform.eulerAngles.y == 180)
                {
                    transform.Translate(Vector2.right * -600 * Time.deltaTime);
                    transform.Translate(Vector2.up * 200 * Time.deltaTime);
                }
                if (transform.eulerAngles.y == 0)
                {
                    transform.Translate(Vector2.right * 600 * Time.deltaTime);
                    transform.Translate(Vector2.up * 200 * Time.deltaTime);
                }
            }

            else if (transform.position.x - boundarie2 > -2)
            {
                if (transform.eulerAngles.y == 0)
                {
                    transform.Translate(Vector2.right * -600 * Time.deltaTime);
                    transform.Translate(Vector2.up * 200 * Time.deltaTime);
                }
                if (transform.eulerAngles.y == 180)
                {
                    transform.Translate(Vector2.right * 600 * Time.deltaTime);
                    transform.Translate(Vector2.up * 200 * Time.deltaTime);
                }
            }
            dWait = 0;
            wait = 0;
            sprite.color = new Color(0.5283019f, 0f, 0f, 1f);
            vida -= (damage);
            if (vida < 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

}