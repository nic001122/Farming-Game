using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    ShopEnter shopEnter;
    void CloseShop()
    {
        shopEnter.shop.SetActive(false);
    }

    void BuyMenu()
    {
        shopEnter.SellButton.SetActive(false);
    }

    void SellMenu()
    {
        shopEnter.BuyButton.SetActive(false);
    }
}   
