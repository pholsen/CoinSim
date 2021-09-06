using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class ByteCoinTrader : MonoBehaviour
{

    private GameObject coinManager;

    [SerializeField] private Text inputText;
    public bool isBuy;
    public bool isSell;

    private void Awake()
    {
        coinManager = GameObject.Find("CoinManager");
    }

    public void isBuyTrigger()
    {
        isBuy = true;

    }

    public void isSellTrigger()
    {

        isSell = true;
    }



    private void FixedUpdate()
    {
        string strInputText = inputText.text;
        float inputValue;
        if (float.TryParse(inputText.text, out inputValue ))
        {
            inputValue = float.Parse(inputText.text);
        }

        /*
         coinManager.GetComponent<CoinController>().byteCoin
        coinManager.GetComponent<CoinController>().byteWallet
        coinManager.GetComponent<CoinController>().playerCoin
        */

        if (0 <= coinManager.GetComponent<CoinController>().byteWallet - inputValue && isSell == true && 0.001f <= inputValue / coinManager.GetComponent<CoinController>().playerCoin)
        {


            coinManager.GetComponent<CoinController>().byteWallet = coinManager.GetComponent<CoinController>().byteWallet - inputValue;

            coinManager.GetComponent<CoinController>().playerCoin = (inputValue * coinManager.GetComponent<CoinController>().byteCoin) + coinManager.GetComponent<CoinController>().playerCoin;

            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;
            isSell = false;

        }
        else if (isSell == true)
        {
            Debug.Log("yetersiz bakiye");
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            isSell = false;
        }



        if (isBuy == true && 0 < inputValue * coinManager.GetComponent<CoinController>().byteCoin && 0 <= coinManager.GetComponent<CoinController>().playerCoin - (inputValue * coinManager.GetComponent<CoinController>().byteCoin))
        {
            coinManager.GetComponent<CoinController>().byteWallet = inputValue + coinManager.GetComponent<CoinController>().byteWallet;

            coinManager.GetComponent<CoinController>().playerCoin = coinManager.GetComponent<CoinController>().playerCoin - (inputValue * coinManager.GetComponent<CoinController>().byteCoin);

            Debug.Log(coinManager.GetComponent<CoinController>().playerCoin + "  " + coinManager.GetComponent<CoinController>().byteWallet);

            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;

            isBuy = false;
        }
        else if (isBuy == true && 0 >= coinManager.GetComponent<CoinController>().playerCoin - inputValue * coinManager.GetComponent<CoinController>().byteCoin)
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
            
        }
        else if ((isBuy == true && 0 >= inputValue * coinManager.GetComponent<CoinController>().byteCoin))
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
            
        }

    }


}

