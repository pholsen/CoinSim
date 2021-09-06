using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinisher : MonoBehaviour
{
    public bool isEnd;

    public Sprite tefeciSonu;
    public Sprite vergiSonu;
    public Sprite kazanmaSonu;

    public int endDay;
    public int endWatch;

    public Image FinishImage;
    void Start()
    {
        FinishImage.enabled = false;
    }

    
    void Update()
    {
        if (GameObject.Find("DayManager").GetComponent<DayController>().daytime==endDay && GameObject.Find("DayManager").GetComponent<DayController>().watchTime==endWatch)
        {
            isEnd = true;
        }

        if (isEnd==true && GameObject.Find("CoinManager").GetComponent<CoinController>().playerCoin>90000 )
        {
            FinishImage.enabled = true;
            GameObject.Find("GameScreen").SetActive(false);
            GameObject.Find("Finish").GetComponent<Image>().sprite = vergiSonu;
            
        }
        else if (isEnd == true && GameObject.Find("CoinManager").GetComponent<CoinController>().playerCoin > 25000 && isEnd == true && GameObject.Find("CoinManager").GetComponent<CoinController>().playerCoin < 27000)
        {
            FinishImage.enabled = true;
            GameObject.Find("Finish").GetComponent<Image>().sprite = kazanmaSonu;
            GameObject.Find("GameScreen").SetActive(false);
        }
        else if (isEnd == true && GameObject.Find("CoinManager").GetComponent<CoinController>().playerCoin < 25000)
        {
            FinishImage.enabled = true;
            GameObject.Find("Finish").GetComponent<Image>().sprite = tefeciSonu;

             GameObject.Find("GameScreen").SetActive(false);
        }
        
    }
}
