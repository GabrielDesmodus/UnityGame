using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des : MonoBehaviour
{
    public GameObject prdes;
    // Start is called before the first frame update
    void Start()
    {
        //prdes = GameObject.Find("projectileDes(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name== "projectileDes(Clone)")
        {
            Destroy(prdes.gameObject, 0.40f);
        }
       
    }

    
}
