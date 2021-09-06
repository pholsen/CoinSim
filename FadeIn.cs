using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image fadeImage;
    private bool isButtonPushed;

    public Text LeftDay;
    
    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.transform.localScale = new Vector3(0,0,0);

        //  GameObject.Find("DayManager").GetComponent<DayController>().daytime
       //   GameObject.Find("DayManager").GetComponent<DayController>().watchTime
    }

    public void ButtonClick()
    {

        isButtonPushed = true;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        
        yield return new WaitForSeconds(time);

        fadeImage.transform.localScale = new Vector3(0, 0, 0);

        LeftDay.canvasRenderer.SetAlpha(0.0f);
    }


    public void FadeAnImage()
    {
        fadeImage.transform.localScale = new Vector3(1,1,1);
        fadeImage.canvasRenderer.SetAlpha(1.0f);
        fadeImage.CrossFadeAlpha(0, 2, false);
        GameObject.Find("BitanceButton").GetComponent<Image>().CrossFadeAlpha(0, 2, false);
        GameObject.Find("WhatsappButton").GetComponent<Image>().CrossFadeAlpha(0, 2, false);
        GameObject.Find("TwitterButton").GetComponent<Image>().CrossFadeAlpha(0, 2, false);








    }

    private void FixedUpdate()
    {


        if (isButtonPushed == true)
        {
            FadeAnImage();


            if ( 10 == GameObject.Find("DayManager").GetComponent<DayController>().watchTime)
            { 
                LeftDay.text = ("KALAN GÜN\n" + (4-GameObject.Find("DayManager").GetComponent<DayController>().daytime));
                LeftDay.canvasRenderer.SetAlpha(1.0f);
                LeftDay.CrossFadeAlpha(0, 2, false);
            }

            
            isButtonPushed = false;
            

            

            
            
           

        }
    }
}
