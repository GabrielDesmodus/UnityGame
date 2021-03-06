﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN : MonoBehaviour {

    public float velocidade;
    private Animator animator;
    private bool atk;
    private Transform player;
    private Controller controller;
    private float dist;
    private Vector3 playerDistance;
    private float wait;
    private float waitForProjectile;
    public float SetVelocidade;
    public int vida;
    private bool death;
    private Rigidbody2D rb;
    private Transform damageSprite;
    private SpriteRenderer damageSpriteRend;
    public bool canFlip;
    public bool canProjectile;
    public GameObject projectile;
    public bool isEN3;
    private float waitForFlip;
    public bool canWalk;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        damageSprite = this.gameObject.transform.GetChild(0);
        damageSpriteRend = damageSprite.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GameObject.FindGameObjectWithTag("GameController").transform.GetComponent<Controller>();
        Debug.Log("Hi");
        controller.EnemyAdd();
        velocidade = Random.Range(1.5f, 3.5f);
        death = false;
    }

    void Update()
    {

        if (canWalk)
        {
            Boundarie();
        }


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
    }

    private void Projectile()
    {
        waitForProjectile += Time.deltaTime;
        if (death == false && waitForProjectile > 3)
        {
            if(transform.eulerAngles.y == 180)
            {
                Instantiate(projectile, new Vector3(transform.position.x-1, transform.position.y, transform.position.z), transform.rotation);
            }
            else if(transform.eulerAngles.y == 0)
            {
                Instantiate(projectile, new Vector3(transform.position.x+1, transform.position.y, transform.position.z), transform.rotation);
            }
           
            waitForProjectile = 0;
        }
    }

    private void Flip()
    {
        //Se o jogador estiver a direita do inimigo
        if (playerDistance.x > 0.5f && transform.eulerAngles.y == 180)
        {
            //Começa a contagem, depois de alguns segundos o inimigo vai se virar na direção do jogador
            waitForFlip += Time.deltaTime;
            if (waitForFlip > 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                waitForFlip = 0;
            }   
        }

        //Se o jogador estiver a esquerda do inimigo
        else if (playerDistance.x <0.5f && transform.eulerAngles.y==0)
        {
            //Começa a contagem, depois de alguns segundos o inimigo vai se virar na direção do jogador
            waitForFlip += Time.deltaTime;
            if (waitForFlip > 1)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                waitForFlip = 0;
            }
        }
    }

    private void Boundarie()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        if (dist > 9){ 
            
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        Player player = colisor.gameObject.GetComponent<Player>();
        if (player != null)
        {
            
            player.TakeDamage(10);
           
            
        }
        else if(colisor.gameObject.tag == "Sword")
        {

            return;
        }
        
    }

    public void TakeDamage(int damage)
    {
        vida -= (damage);

        if (vida <= 0 && death == false)
        {
            Destroy(this.gameObject,1);
            death = true;
            controller.EnemyRemov();
            
            if (isEN3 == false)
            {
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
