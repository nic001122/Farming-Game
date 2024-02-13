using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] ShopEnter shopEnter;
    public void CloseShop()
    {
        shopEnter.shop.SetActive(false);
    }

    public void BuyMenu()
    {
        shopEnter.SellButton.SetActive(false);
        shopEnter.BuyButton.SetActive(false);

        shopEnter.shopBg.transform.localScale = new Vector2 (0.5100411f, 0.5f);
    }

    public void SellMenu()
    {
        shopEnter.BuyButton.SetActive(false);
        shopEnter.SellButton.SetActive(false);

        shopEnter.shopBg.transform.localScale = new Vector2 (0.5100411f, 0.5f);
    }
}   
