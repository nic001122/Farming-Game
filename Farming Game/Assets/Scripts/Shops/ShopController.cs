using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] ShopEnter shopEnter;
    public GameObject openUpMenu;
    public GameObject sellMenu;
    public GameObject buyMenu;

    public CounterText cntrText;
    public GameObject notEnoughBeetrootSeedsText;

    public Slider beetrootSlider;
    public TextMeshProUGUI textBeetrootSellAmount;
    [SerializeField] float beetrootSellAmount;
    [SerializeField] int beetrootValue = 1;

    public void CloseShop()
    {
        shopEnter.shop.SetActive(false);
    }

    public void BuyMenu()
    {
        shopEnter.SellButton.SetActive(false);
        shopEnter.BuyButton.SetActive(false);
        buyMenu.SetActive(true);

        shopEnter.shopBg.transform.localScale = new Vector2 (0.5100411f, 0.5f);
    }

    public void SellMenu()
    {
        shopEnter.BuyButton.SetActive(false);
        shopEnter.SellButton.SetActive(false);
        sellMenu.SetActive(true);

        shopEnter.shopBg.transform.localScale = new Vector2 (0.5100411f, 0.5f);
    }

    public void GoBack()
    {
        openUpMenu.SetActive(true);
        sellMenu.SetActive(false);
        buyMenu.SetActive(false);
        shopEnter.BuyButton.SetActive(true);
        shopEnter.SellButton.SetActive(true);

        shopEnter.shopBg.transform.localScale = new Vector2 (0.5100411f, 0.1867f);
    }

    public void SellBeetrootSeeds()
    {
        //if(beetrootSellAmount <= cntrText.beetrootSeeds && cntrText.beetrootSeeds > 0)
        //{
            //cntrText.beetrootSeeds -= beetrootSellAmount;
            //cntrText.money += beetrootSellAmount * beetrootValue;
            //notEnoughBeetrootSeedsText.SetActive(false);
        //}

        //else
        //{
            //notEnoughBeetrootSeedsText.SetActive(true);
        //}
    }

    public void BuyBeetrootSeeds()
    {
        
    }

    public void Update()
    {
        beetrootSellAmount = beetrootSlider.value;
        textBeetrootSellAmount.text = beetrootSellAmount.ToString();
    }
}   
