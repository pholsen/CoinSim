using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xxxrpCoinTrader : MonoBehaviour
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
         coinManager.GetComponent<CoinController>().xxxrpCoin
        coinManager.GetComponent<CoinController>().xxxrpWallet
        coinManager.GetComponent<CoinController>().playerCoin
        */

        if (0 <= coinManager.GetComponent<CoinController>().xxxrpWallet - inputValue && isSell == true && 0.001f <= inputValue / coinManager.GetComponent<CoinController>().playerCoin)
        {


            coinManager.GetComponent<CoinController>().xxxrpWallet = coinManager.GetComponent<CoinController>().xxxrpWallet - inputValue;

            coinManager.GetComponent<CoinController>().playerCoin = (inputValue * coinManager.GetComponent<CoinController>().xxxrpCoin) + coinManager.GetComponent<CoinController>().playerCoin;


            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;
            isSell = false;

        }
        else if (isSell == true)
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isSell = false;
        }



        if (isBuy == true && 0 < inputValue * coinManager.GetComponent<CoinController>().xxxrpCoin && 0 <= coinManager.GetComponent<CoinController>().playerCoin - (inputValue * coinManager.GetComponent<CoinController>().xxxrpCoin))
        {
            coinManager.GetComponent<CoinController>().xxxrpWallet = inputValue + coinManager.GetComponent<CoinController>().xxxrpWallet;

            coinManager.GetComponent<CoinController>().playerCoin = coinManager.GetComponent<CoinController>().playerCoin - (inputValue * coinManager.GetComponent<CoinController>().xxxrpCoin);

            Debug.Log(coinManager.GetComponent<CoinController>().playerCoin + "  " + coinManager.GetComponent<CoinController>().xxxrpWallet);

            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = false;
            isBuy = false;
        }
        else if ((isBuy == true && 0 >= inputValue * coinManager.GetComponent<CoinController>().xxxrpCoin))
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
        }


        else if (isBuy == true && 0 >= coinManager.GetComponent<CoinController>().playerCoin - inputValue * coinManager.GetComponent<CoinController>().xxxrpCoin)
        {
            GameObject.Find("YetersizBakiyeManager").GetComponent<YetersizBakiyeController>().isYetersiz = true;
            Debug.Log("yetersiz bakiye");
            isBuy = false;
        }
        
    }
}
