using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool canDoDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        EN enemy = other.GetComponent<EN>();
       
        if (enemy != null && !canDoDamage)
        {
            enemy.TakeDamage(10);
            enemy.DamageSpriteF(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        EN enemy = other.GetComponent<EN>();

        if (enemy != null && !canDoDamage)
        {
            enemy.TakeDamage(10);
            enemy.DamageSpriteF(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EN enemy = other.GetComponent<EN>();
        if (enemy != null)
        {
            enemy.DamageSpriteF(false);
           
        }
    }
}
