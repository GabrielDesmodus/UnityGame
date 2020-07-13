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
                Instantiate(enemy1s, new Vector3(-6, 26, -22), Quaternion.Euler(0, 180, 0));
                Instantiate(enemy2, new Vector3(4.74f, 30.84f, -22), Quaternion.Euler(0, 0, 0));
                Instantiate(enemy1s, new Vector3(-35, 5, -22), transform.rotation);
                break;
            case 2:
                Instantiate(enemy1s, new Vector3(-6, 26, -22), Quaternion.Euler(0, 180, 0));
                Instantiate(enemy2, new Vector3(4.74f, 30.84f, -22), Quaternion.Euler(0, 0, 0));
                Instantiate(enemy1s, new Vector3(-35, 5, -22), transform.rotation);
                break;

        }
        
    }
}
