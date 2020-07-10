using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject enemies;
    private Transform enemy;
    public Vector2 position;
    public Vector2 position2;
    public Vector2 position3;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyCheck()
    {
        if (enemy == null)
        {
            InstantEnemy();
        }
    }

    void InstantEnemy()
    {
        Instantiate(enemies, position, transform.rotation);
    }
}
