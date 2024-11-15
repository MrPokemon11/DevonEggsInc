using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SpawnChicken : MonoBehaviour
{
    //singleton
    public static SpawnChicken ChickenInstance { get; private set; }
    
    [SerializeField] private GameObject chicken;
    [SerializeField] private GameObject chickenSpawn;
    Vector3 chickenSpawnPos;

    private float chickenMultiplier = 1;

    private float timer = 60f;
    private int multCount = 0;

    private bool fight = false;

    private void Awake() 
    {
        if (ChickenInstance != null && ChickenInstance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            ChickenInstance = this; 
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        chickenSpawnPos = chickenSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fight = !fight;
            }

            if (fight)
            {
                GameObject[] evilChickens = GameObject.FindGameObjectsWithTag("EvilChicken");
                foreach (var echickens in evilChickens)
                {
                    echickens.GetComponent<Chicken>().decrementHealth();
                }
            }
            else
            {
                for (float i = chickenMultiplier; i > 0; i -= 1f)
                {
                    if (i > 0) Instantiate(chicken, chickenSpawnPos, Quaternion.identity);
                    else
                    {
                        float more = Random.Range(0f, 1f);
                        if (more < chickenMultiplier)
                        {
                            Instantiate(chicken, chickenSpawnPos, Quaternion.identity);
                        }
                    }
                }
                timer = 60f;
                multCount++;
                chickenMultiplier = 1.0f + (multCount % 200f);
            }
            
        }

        if (timer <= 0)
        {
            chickenMultiplier = 1f;
        }
        
    }
    
    
}
