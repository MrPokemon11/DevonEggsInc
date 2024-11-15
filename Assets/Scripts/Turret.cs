using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate;

    private GameObject target = null;

    [SerializeField] private TextMeshProUGUI gunshot;
    [SerializeField] private GameObject turret;
    [SerializeField] private GameObject spawn;

    private bool spawned = false;
    
    // Update is called once per frame
    void Update()
    {
        gunshot.text = "";
        if (target == null && spawned != false)
        {
            target = GameObject.FindGameObjectWithTag("EvilChicken");
        }

        if (target != null && spawned != false)
        {
            Fire();
            gunshot.text = "bang";
            
        }
    }

    void Fire()
    {
        for (float i = fireRate; i > 0; i -= Time.deltaTime)
        {
            
        }
        target.GetComponent<Chicken>().decrementHealth();
    }

    public void SpawnTurret()
    {
        turret.transform.position = spawn.transform.position;
        spawned = true;
    }
}
