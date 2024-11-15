using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Chicken : MonoBehaviour
{
    private bool isEvil = false;
    private int health = 1;
    [SerializeField] private GameObject target;
    
    private void Awake()
    {
        float evilRandom = Random.Range(0.0f, 1.0f);
        evilRandom *= 100.0f;
        int evilInt = (int)evilRandom;
        isEvil = evilInt <= 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isEvil)
        {
            health = 3;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (isEvil)
        {
            EvilUpdate();
        }
        else
        {
            GoodUpdate();
        }
    }

    void GoodUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * 10.0f);
    }

    void EvilUpdate()
    {
        
    }
}
