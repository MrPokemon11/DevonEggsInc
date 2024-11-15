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
    private Rigidbody rb;
    
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
            health = 25;
            gameObject.tag = "EvilChicken";
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 2f, gameObject.transform.localScale.y * 2f, gameObject.transform.localScale.z * 2f);
        }
        rb = GetComponent<Rigidbody>();
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
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * 15f);
            EvilUpdate();
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * 10.0f);
            GoodUpdate();
        }
        
    }

    void GoodUpdate()
    {

        
    }

    void EvilUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Chicken");
        }

        if (target == null)
        {
            rb.AddForce(Vector3.up * 100f, ForceMode.Impulse);
            Destroy(gameObject, 2f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isEvil)
        {
            if (other.gameObject.tag == "Chicken")
            {
                other.gameObject.GetComponent<Chicken>().decrementHealth();
            }
        }
        else if (other.gameObject.tag == "Finish" && !isEvil)
        {
            Destroy(gameObject);
            
        }
    }

    public void decrementHealth()
    {
        health--;
    }
}
