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
    private int wave=5;
    public Animator block;
    List<GameObject> listOfOpponents = new List<GameObject>();
    
    public void EnemyAdd()
    {
        qty++;
    }

    public void EnemyRemov()
    {
        qty--;
  
        if (qty<=0)
        {
            InstantEnemy();
        }
    }

    void Unlock()
    {
        block.SetBool("unblock", true);
    }

    void InstantEnemy()
    {
        wave++;
        switch (wave)
        {
            case 1:
                Instantiate(enemy1s, new Vector3(18.03f, 17.39f, -22), Quaternion.Euler(0, 180, 0));
                Instantiate(enemy2, new Vector3(4.74f, 30.84f, -22), Quaternion.Euler(0, 0, 0));
                Instantiate(enemy1s, new Vector3(-35, 5, -22), transform.rotation);
                break;

            case 2:
                Instantiate(enemy, new Vector3(14.2f, 9.59f, -22), Quaternion.Euler(0, 180, 0));
                Instantiate(enemy, new Vector3(-1.17f, 9.59f, -22), Quaternion.Euler(0, 0, 0));
                Instantiate(enemy, new Vector3(-35.87f, 9.59f, -22), transform.rotation);
                break;

            case 3:
                Instantiate(enemy1s, new Vector3(10.03f, 14.16f, -22), Quaternion.Euler(0, 180, 0));
                Instantiate(enemy1s, new Vector3(-38.44f, 9.59f, -22), Quaternion.Euler(0, 0, 0));
                break;

            case 4:
                Instantiate(enemy1s, new Vector3(-12.57f, 17.39f, -22), Quaternion.Euler(0, 180, 0));
                break;

            case 5:
                Instantiate(enemy1s, new Vector3(18.03f, 9, -22), Quaternion.Euler(0, 180, 0));
                Instantiate(enemy1s, new Vector3(-39.78f, 9, -22), Quaternion.Euler(0, 180, 0));
                Instantiate(enemy2, new Vector3(-11.1f, 24.16f, -22), Quaternion.Euler(0, 0, 0));
                break;

            case 6:
                Unlock();
                break;  
        }
        
    }
}
