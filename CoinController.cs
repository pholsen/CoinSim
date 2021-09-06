using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public Text pinkMarket;
    public Text pinkWalletTop;
    [HideInInspector] public int pinkPercent;

    public Text byteMarket;
    public Text byteWalletTop;
    [HideInInspector] public int bytePercent;

    public Text doggyMarket;
    public Text doggyWalletTop;
    [HideInInspector] public int doggyPercent;

    public Text methMarket;
    public Text methWalletTop;
    [HideInInspector] public int methPercent;

    public Text xxxrpMarket;
    public Text xxxrpWalletTop;
    [HideInInspector] public int xxxrpPercent;



    public Text PlayerWallet;
   
    /// </Coins>
    public float playerCoin;

    public float pinkCoin;
   [HideInInspector] public float pinkWallet;

    public float xxxrpCoin;
    [HideInInspector] public float xxxrpWallet;

    public float methCoin;
    [HideInInspector] public float methWallet;

    public float byteCoin;
    [HideInInspector] public float byteWallet;

    public float doggyCoin;
    [HideInInspector] public float doggyWallet;


    private bool isPushed;

    public int PriceRange;

    public int DailyRange;

    public int BullHour;

    public int BearHour;
   

    public GameObject dayManager;

    public int BullRange;

    private int BearRange;

    public bool isBullorBear;



    private void Awake()
    {
        dayManager = GameObject.Find("DayManager");
        
    }

    public float DailyPriceChanges(float anyCoin)
    {

        DailyRange = Random.Range(-15, 15);
        anyCoin = anyCoin + (anyCoin * DailyRange / 100);
        
        return anyCoin;
         
    }

    

    private void Start()
    {
        pinkCoin = DailyPriceChanges(pinkCoin);
        
        byteCoin = DailyPriceChanges(byteCoin);
        doggyCoin = DailyPriceChanges(doggyCoin);
        methCoin = DailyPriceChanges(methCoin);
        xxxrpCoin = DailyPriceChanges(xxxrpCoin);
        
    }
    public void isButtonPushed()

    {
        isPushed = true;


    }
    
    public float Bull(float anyCoin,int anyTimeLimit,int BullDay)
    {
      BullHour =  Random.Range(anyTimeLimit,10 );
        BullOrBearTime(BullDay, BullHour);
        
        if (isBullorBear==true)
        {
            PriceRange = Random.Range(100, 1000);
            anyCoin = anyCoin + (anyCoin * PriceRange / 100);

            isBullorBear = false;

            return anyCoin;


        }
        else
        {
            isBullorBear = false;
            return anyCoin;
           
        }
    }
    public float Bear(float anyCoin,int anyTimeLimit,int BearDay)
    {

        BearHour = Random.Range(anyTimeLimit, 10);

        BullOrBearTime(BearDay, BearHour);
        if (isBullorBear == true)
        {
            PriceRange = Random.Range(-50, -100);
            anyCoin = anyCoin + (anyCoin * PriceRange / 100);

            isBullorBear = false;

            return anyCoin;


        }
        else
        {
            isBullorBear = false;
            return anyCoin;

        }

    }



    public void BullOrBearTime(int anyDay, int anyTime)
    {
        if (dayManager.GetComponent<DayController>().daytime == anyDay && dayManager.GetComponent<DayController>().watchTime == anyTime)
        {
            isBullorBear = true;
        }


    }

    int Percent(int anyPercent)
    {
        if (PriceRange != 0)
        {
            anyPercent = PriceRange;
            PriceRange = 0;
           

            return anyPercent;
        }
        
        else
        {
            anyPercent = DailyRange;
            return anyPercent;
        }

    }

    

    public void DayTurn()
    {

        if (isPushed == true)
        {

            pinkCoin = DailyPriceChanges(pinkCoin);
            pinkCoin = Bear(pinkCoin,6,0);
            pinkCoin = Bull(pinkCoin, 2, 3);
            
            pinkPercent = Percent(pinkPercent);

             byteCoin = DailyPriceChanges(byteCoin);
            byteCoin = Bull(byteCoin, 7, 0);
            byteCoin = Bull(byteCoin, 3, 1);
            byteCoin = Bear(byteCoin, 4, 4);
            bytePercent = Percent(bytePercent) ;
            
           
            doggyCoin = DailyPriceChanges(doggyCoin);
            doggyCoin = Bear(doggyCoin, 4, 3);
            doggyCoin = Bull(doggyCoin, 1, 1);
            doggyPercent = Percent(doggyPercent);
            

            methCoin = DailyPriceChanges(methCoin);
            methCoin = Bear(methCoin,2,2);
            methCoin = Bull(methCoin, 2, 3);
            methPercent = Percent(methPercent);


            xxxrpCoin = DailyPriceChanges(xxxrpCoin);
            xxxrpCoin = Bull(xxxrpCoin,4,2);
            xxxrpCoin = Bear(xxxrpCoin, 1, 0);
            xxxrpPercent = Percent(xxxrpPercent);
            

            isPushed = false;
        }


    }
    private void FixedUpdate()
    {

        DayTurn();


        PlayerWallet.text = ( playerCoin.ToString());
        pinkWalletTop.text = ("PINKCOIN: "+pinkWallet.ToString());
        byteWalletTop.text = ("BYTECOIN: " + byteWallet.ToString());
        doggyWalletTop.text = ("DOGGYCOIN: "+doggyWallet.ToString());
        methWalletTop.text = ( "METHCOIN: "+methWallet.ToString());
        xxxrpWalletTop.text = ("XXXRPCOIN: "+xxxrpWallet.ToString());

        GreenOrRed(pinkMarket, pinkPercent);
        pinkMarket.text = ("PINK/USD\n" + pinkCoin.ToString()+" $" + "   % " + pinkPercent);
        GreenOrRed(byteMarket, bytePercent);
        byteMarket.text = ("BYTC/USD\n" + byteCoin.ToString() + " $" + "   % " + bytePercent);
        GreenOrRed(doggyMarket, doggyPercent);
        doggyMarket.text = ("DOGGY/USD\n" + doggyCoin.ToString() + " $" + "   % " + doggyPercent);
        GreenOrRed(methMarket, methPercent);
        methMarket.text = ("METH/USD\n" + methCoin.ToString() + " $" + "   % " + methPercent);
        GreenOrRed(xxxrpMarket, xxxrpPercent);
        xxxrpMarket.text = ("XXXRP/USD\n" + xxxrpCoin.ToString() + " $" + "   % " + xxxrpPercent);


       
    }

    void GreenOrRed(Text anyText , float anyPercent)
    {
        if (anyPercent<0)
        {
            anyText.color = Color.red;
        }
        else if (anyPercent>0)
        {
            anyText.color = Color.green;
        }
        else
        {
            anyText.color = Color.yellow;
        }

   
    }


}
