using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager ManagerInstance { get; private set; }
    
    private float money = 0;
    [SerializeField] private TextMeshProUGUI moneyText;
    private int chickenCount = 0;
    [SerializeField] private TextMeshProUGUI chickenText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money += chickenCount * 0.02f * Time.deltaTime;
        moneyText.text = "Money: $" + money.ToString("#,0");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chicken"))
        {
            chickenCount += 1;
            chickenText.text = "Chickens: " + chickenCount.ToString();
        }
    }
}
