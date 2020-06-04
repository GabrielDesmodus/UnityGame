using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN2 : MonoBehaviour
{
    private float wait;
    public GameObject projectile2;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        wait += Time.deltaTime;

        if (wait > 3)
        {
            
            Instantiate(projectile2, transform.position, transform.rotation);
            
            wait = 0;
            

        }
        else if (wait < 3)
        {
            
        }

  
    }
}
