using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinkCoinTrade : MonoBehaviour
{
    private GameObject coinManager;
   public Text inputPinkText;
    
    public bool isBuy;
    public bool isSell;

    private bool isCalculated = true;


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

    

    void FixedUpdate()
    {

        string strPinkInputValue = inputPinkText.text;
        float inputPinkValue;
        if (float.TryParse(strPinkInputValue, out inputPinkValue))
        {
            inputPinkValue = float.Parse(strPinkInputValue);
        }


        if (0<=coinManager.GetComponent<CoinController>().pinkWallet - inputPinkValue && isSell == true && 0.001f <= inputPinkValue / coinManager.GetComponent<CoinController>().playerCoin)
        {

            
            coinManager.GetComponent<CoinController>().pinkWallet = coinManager.GetComponent<CoinController>().pinkWallet - inputPinkValue;

            coinManager.GetComponent<CoinController>().playerCoin = (inputPinkValue * coinManager.GetComponent<CoinController>().pinkCoin) + coinManager.GetComponent<CoinController>().playerCoin;

            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;
            isSell = false;

           

        }
        else if (isSell == true && inputPinkValue == 0 && 0>= coinManager.GetComponent<CoinController>().pinkWallet - inputPinkValue)
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isSell = false;
            
        }



        if (isBuy == true && 0 < inputPinkValue * coinManager.GetComponent<CoinController>().pinkCoin && 0 <= coinManager.GetComponent<CoinController>().playerCoin - (inputPinkValue * coinManager.GetComponent<CoinController>().pinkCoin))
        {
            coinManager.GetComponent<CoinController>().pinkWallet = inputPinkValue + coinManager.GetComponent<CoinController>().pinkWallet;

            coinManager.GetComponent<CoinController>().playerCoin = coinManager.GetComponent<CoinController>().playerCoin - (inputPinkValue * coinManager.GetComponent<CoinController>().pinkCoin);

            Debug.Log(coinManager.GetComponent<CoinController>().playerCoin + "  " + coinManager.GetComponent<CoinController>().pinkWallet);

            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;

            isBuy = false;
        }
        else if (isBuy == true && 0 >= coinManager.GetComponent<CoinController>().playerCoin - inputPinkValue * coinManager.GetComponent<CoinController>().pinkCoin)
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
            
        }
        else if ((isBuy == true && 0 >= inputPinkValue * coinManager.GetComponent<CoinController>().pinkCoin))
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
        }

       



        
    }
}
