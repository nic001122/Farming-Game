using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEnter : MonoBehaviour
{
    public GameObject shop;
    public GameObject shopBg;
    public GameObject BuyButton;
    public GameObject SellButton;

    public ShopController shopController;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            shop.SetActive(true);
            BuyButton.SetActive(true);
            SellButton.SetActive(true);
            shopController.buyMenu.SetActive(false);
            shopController.sellMenu.SetActive(false);

            shopBg.transform.localScale = new Vector2(0.5100411f, 0.1867f);
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
