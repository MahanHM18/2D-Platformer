using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public GameObject ShopPanel;

    public Text CoinTXT;

    private void Awake()
    {
        if (Instance == null)
            Instance = this; 
    }

    private void Start()
    {
        CoinTXT.text = GameManager.Coin.ToString();
    }
    public void Increase(int value)
    {
        GameManager.Coin += value;
        CoinTXT.text = GameManager.Coin.ToString();
    }

    public void Decrease(int value)
    {
        GameManager.Coin -= value;
        CoinTXT.text = GameManager.Coin.ToString();
    }

    public void Back()
    {
        Time.timeScale = 1;
        ShopPanel.SetActive(false);
    }

    public void ActiveShopPanel()
    {
        ShopPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
