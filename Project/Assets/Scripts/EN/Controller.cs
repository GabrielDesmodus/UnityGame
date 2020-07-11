using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject enemies;
    private Transform enemy;
    public Vector3 position;
    public Vector3 position2;
    public Vector3 position3;
    private int qty = 0;
    List<GameObject> listOfOpponents = new List<GameObject>();
    
    public void EnemyAdd()
    {
        qty++;
    }

    public void EnemyRemov()
    {
        qty--;
        Debug.Log(qty);
  
        if (qty<=0)
        {
            Debug.Log("YES");
            InstantEnemy();
        }
    }

    void InstantEnemy()
    {
        Instantiate(enemies, position, transform.rotation);
        Instantiate(enemies, position2, transform.rotation);
    }
}
