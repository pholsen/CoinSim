using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayController : MonoBehaviour
{
    public Text timeText;
    public bool isNext;
    public int watchTime;
    public int daytime;

    
  
    public void ClickNextButton()
    {

        isNext = true;
       

            


    }

    
   public void FixedUpdate()
    {
        if (isNext == true)
        {
            watchTime++;
            

            if (watchTime==11)
            {
                daytime++;
                watchTime = 0;
            }
            timeText.text = ((14 + watchTime) + ".00\n" + "0" + (4 + daytime) + ".05.2021");


            isNext = false;
        }
    }

   
}
