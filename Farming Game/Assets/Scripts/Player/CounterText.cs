using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterText : MonoBehaviour
{
    public TextMeshProUGUI moneyCounter;
    public float money;



    // Update is called once per frame
    void Update()
    {
        moneyCounter.text = "Money: " + money.ToString();

        
    }
}
