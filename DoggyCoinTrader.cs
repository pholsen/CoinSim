using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoggyCoinTrader : MonoBehaviour
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
        if (float.TryParse(inputText.text, out inputValue))
        {
            inputValue = float.Parse(inputText.text);
        }

        /*
         coinManager.GetComponent<CoinController>().doggyCoin
        coinManager.GetComponent<CoinController>().doggyWallet
        coinManager.GetComponent<CoinController>().playerCoin
        */

        if (0 <= coinManager.GetComponent<CoinController>().doggyWallet - inputValue && isSell == true && 0.001f <= inputValue / coinManager.GetComponent<CoinController>().playerCoin)
        {


            coinManager.GetComponent<CoinController>().doggyWallet = coinManager.GetComponent<CoinController>().doggyWallet - inputValue;

            coinManager.GetComponent<CoinController>().playerCoin = (inputValue * coinManager.GetComponent<CoinController>().doggyCoin) + coinManager.GetComponent<CoinController>().playerCoin;
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;
            isSell = false;

        }
        else if (isSell == true)
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isSell = false;
        }



        if (isBuy == true && 0 < inputValue * coinManager.GetComponent<CoinController>().doggyCoin && 0 <= coinManager.GetComponent<CoinController>().playerCoin - (inputValue * coinManager.GetComponent<CoinController>().doggyCoin ))
        {
            coinManager.GetComponent<CoinController>().doggyWallet = inputValue + coinManager.GetComponent<CoinController>().doggyWallet;

            coinManager.GetComponent<CoinController>().playerCoin = coinManager.GetComponent<CoinController>().playerCoin - (inputValue * coinManager.GetComponent<CoinController>().doggyCoin);

            Debug.Log(coinManager.GetComponent<CoinController>().playerCoin + "  " + coinManager.GetComponent<CoinController>().doggyWallet);

            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;
            isBuy = false;
        }
        else if (isBuy == true && 0 >= coinManager.GetComponent<CoinController>().playerCoin - inputValue * coinManager.GetComponent<CoinController>().doggyCoin)
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
        }
        else if ((isBuy == true && 0 >= inputValue * coinManager.GetComponent<CoinController>().doggyCoin))
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
        }


      
    }
}
