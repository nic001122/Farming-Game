using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnter : MonoBehaviour
{
    public GameObject shop;
    public GameObject shopBg;
    public GameObject BuyButton;
    public GameObject SellButton;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            shop.SetActive(true);
            BuyButton.SetActive(true);
            SellButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            shop.SetActive(false);
        }
    }
}
