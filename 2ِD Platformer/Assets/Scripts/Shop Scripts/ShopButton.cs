using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private int Price = 0;

    private Text btnText;
    void Awake()
    {
        btnText = transform.GetChild(0).GetComponent<Text>();
    }

    private void Start()
    {
        btnText.text = Price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        if (GameManager.Coin >= Price)
        {
            Debug.Log("bought");
            UIManager.Instance.Decrease(Price);
        }
        else
        {
            Debug.Log("Faild");
        }
    }
}
