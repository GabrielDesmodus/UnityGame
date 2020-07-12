using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy1s;
    public Vector3 position;
    public Vector3 position2;
    public Vector3 position3;
    private int qty;
    private int wave;
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
        wave++;
        switch (wave)
        {
            case 1:
                Instantiate(enemy1s, new Vector3(-6, 21, -22), transform.rotation);
                Instantiate(enemy2, new Vector3(18, 14, -22), transform.rotation);
                Instantiate(enemy1s, new Vector3(-35, 5, -22), transform.rotation);
            break;
        }
        
    }
}
