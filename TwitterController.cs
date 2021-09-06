using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwitterController : MonoBehaviour
{
    public Sprite Twit1;
    public Sprite Twit2;
    public Sprite Twit3;
    public Sprite Twit4;
    public Sprite Twit5;
    void Start()
    {
        //GameObject.Find("DayManager").GetComponent<DayController>().daytime ==  && GameObject.Find("DayManager").GetComponent<DayController>().watchTime == endWatch
    }

    
    void Update()
    {
        if (GameObject.Find("DayManager").GetComponent<DayController>().daytime == 1  && GameObject.Find("DayManager").GetComponent<DayController>().watchTime == 0)
        {
            GameObject.Find("Twits").GetComponent<Image>().sprite = Twit2;

        }
        if (GameObject.Find("DayManager").GetComponent<DayController>().daytime == 2 && GameObject.Find("DayManager").GetComponent<DayController>().watchTime == 0)
        {
            GameObject.Find("Twits").GetComponent<Image>().sprite = Twit3;

        }
        if (GameObject.Find("DayManager").GetComponent<DayController>().daytime == 3 && GameObject.Find("DayManager").GetComponent<DayController>().watchTime == 0)
        {
            GameObject.Find("Twits").GetComponent<Image>().sprite = Twit4;

        }
        if (GameObject.Find("DayManager").GetComponent<DayController>().daytime == 4 && GameObject.Find("DayManager").GetComponent<DayController>().watchTime == 0)
        {
            GameObject.Find("Twits").GetComponent<Image>().sprite = Twit5;

        }
    }
}
