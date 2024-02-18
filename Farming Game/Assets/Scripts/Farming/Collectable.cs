using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CounterText cntrTxt;

    bool inRange = false;

    void Update()
    {
      
       
        if(inRange)
        {
            PickUp();
        }
        
    }

    private void PickUp()
    {
        Destroy(gameObject);
        if(gameObject.CompareTag("Beetroot Seed"))
        {
            cntrTxt.beetrootSeeds += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
