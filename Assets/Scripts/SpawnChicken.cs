using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnChicken : MonoBehaviour
{
    //singleton
    public static SpawnChicken Instance { get; private set; }
    
    [SerializeField] private GameObject chicken;
    [SerializeField] private GameObject chickenSpawn;
    Vector3 chickenSpawnPos;

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
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
        
        if (Input.anyKeyDown)
        {
            Instantiate(chicken, chickenSpawnPos, Quaternion.identity);
        }
        
    }
    
    
}
