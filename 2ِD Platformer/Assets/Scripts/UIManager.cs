using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;


    public Text CoinTXT;

    private void Awake()
    {
        if (Instance == null)
            Instance = this; 
    }

    public void SetCoin(int value)
    { 
        CoinTXT.text = value.ToString();
    }
}
