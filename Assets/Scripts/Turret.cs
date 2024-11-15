using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate;

    private GameObject target = null;
    

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("EvilChicken");
        }
    }

    void Fire()
    {
        
    }
}
