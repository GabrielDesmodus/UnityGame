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
    public Transform sword;
    private Animator animator;
    public Animator belt_anim;
    public int maxVida;
    public int vida;
    public int noOfClicks;
    public float lastClickedTime;
    public float maxComboDelay;
    public float iFrame; //Iframe time
    private SpriteRenderer sprite;
    public SpriteRenderer belt_sprite;
    private Rigidbody2D rigidbody2D;
    private GameObject HB;
    private HB hb;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();
        HB = GameObject.Find("HB");
        hb = HB.GetComponent<HB>();
        vida = maxVida;
        noOfClicks = 0;
        iFrame = 2;
    }
    void FixedUpdate()
    {
        if (!estaNoChao)
        {
            rigidbody2D.gravityScale += 1;
            velocidade = 24;
        }

        else
        {
            rigidbody2D.gravityScale = 1;
            velocidade = 14;
        }
        iFrame += Time.deltaTime;
        lastClickedTime += Time.deltaTime;
    }
    void Update()
    {
        

        if (iFrame < 1)
        {
            
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            belt_sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            Physics2D.IgnoreLayerCollision(0, 11, true);
            hb.Damage(true);
        }

        else
        {
            Physics2D.IgnoreLayerCollision(0, 11, false);
            Color myColor = new Color();
            ColorUtility.TryParseHtmlString("#E0E0E0", out myColor);
            sprite.color = myColor;
            belt_sprite.color = Color.white;
            hb.Damage(false);
        }

        
        Attack();
        Movimentacao();
    }

    void Attack()
    {
        if(lastClickedTime > maxComboDelay || iFrame < 0.5f)
        {
            noOfClicks = 0;
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", false);
            lastClickedTime = 0.4f;
        }
        
        if(Input.GetButtonDown("Fire1") && lastClickedTime < maxComboDelay && lastClickedTime > 0.4f && noOfClicks== 0 && iFrame > 1)
        {
            animator.SetBool("Attack1", true);
            lastClickedTime = 0;
            noOfClicks = 1;
            
        }

        if (Input.GetButtonDown("Fire1") && lastClickedTime < maxComboDelay && lastClickedTime > 0.4f && noOfClicks== 1 && iFrame > 1)
        {
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", true);
            lastClickedTime = 0;
            noOfClicks = 2;
        }

        if (Input.GetButtonDown("Fire1") && lastClickedTime < maxComboDelay && lastClickedTime > 0.4f && noOfClicks == 2 && iFrame > 1)
        {
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", true);
            lastClickedTime = 0;
            noOfClicks = 3;
        }

        if (lastClickedTime < maxComboDelay && lastClickedTime > 0.6f && noOfClicks == 3 )
        {
            animator.SetBool("Attack3", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack1", false);
            lastClickedTime = 0;
            noOfClicks = 0;
        }
    }

    //The enemy calls this function to deal damage to the player
    void Movimentacao()
    {
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

        belt_anim.SetFloat("yvelocity", rigidbody2D.velocity.y);
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        belt_anim.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        estaNoChao = Physics2D.Raycast(chaoVerificador.position, -Vector2.up, 1, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetBool("chao", estaNoChao);
        belt_anim.SetBool("chao", estaNoChao);
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