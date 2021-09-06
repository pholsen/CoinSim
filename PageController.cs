using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    private bool isPushedTwitter;
    private bool isPushedBitance;
    private bool isPushedWhatsapp;


    
    public void TwitterButton()
    {

        isPushedTwitter = true;

    }
    public void BitanceButton()
    {

        isPushedBitance = true;

    }
    public void WhatsappButton()
    {

        isPushedWhatsapp = true;
    }
    void Start()
    {
        GameObject.Find("TwitterCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("BitanceCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("WhatsappButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Bitance").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Twitter").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("NextButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("WhatsappCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("WhatsappCanvas").GetComponent<Canvas>().enabled = true;


    }

    /*GameObject.Find("TwitterButton").transform.localScale = new Vector3(0, 0, 0);
    GameObject.Find("Bitance").SetActive(false);*/
    void FixedUpdate()
    {
        if (isPushedTwitter == true)
        {
            
            
            HideMethod(GameObject.Find("TwitterButton"), GameObject.Find("Twitter"), GameObject.Find("TwitterCanvas"), GameObject.Find("Bitance"), GameObject.Find("BitanceCanvas"), GameObject.Find("WhatsApp"), GameObject.Find("WhatsappCanvas"));
            isPushedTwitter = false;
            GameObject.Find("BitanceButton").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("WhatsappButton").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("NextButton").transform.localScale = new Vector3(0, 0, 0);

        }

        if(isPushedBitance == true)
        {

            HideMethod(GameObject.Find("BitanceButton"), GameObject.Find("Bitance"), GameObject.Find("BitanceCanvas"), GameObject.Find("WhatsApp"), GameObject.Find("WhatsappCanvas"), GameObject.Find("Twitter"), GameObject.Find("TwitterCanvas"));
            isPushedBitance = false;
            GameObject.Find("TwitterButton").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("WhatsappButton").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("NextButton").transform.localScale = new Vector3(1, 1, 1);

        }

        if (isPushedWhatsapp == true)
        {

            HideMethod(GameObject.Find("WhatsappButton"), GameObject.Find("WhatsApp"), GameObject.Find("WhatsappCanvas"), GameObject.Find("Bitance"), GameObject.Find("BitanceCanvas"), GameObject.Find("Twitter"), GameObject.Find("TwitterCanvas"));
            isPushedWhatsapp = false;
            GameObject.Find("TwitterButton").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("BitanceButton").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("NextButton").transform.localScale = new Vector3(0, 0, 0);

        }

    }
    void HideMethod(GameObject anyButton,GameObject SelectedPage,GameObject selectedCanvas, GameObject otherPage1 ,GameObject otherCanvas1,GameObject otherPage2,GameObject otherCanvas2)
    {
        anyButton.transform.localScale = new Vector3(0, 0, 0);
        
        SelectedPage.transform.localScale = new Vector3(0.9264057f, 0.9244603f, 0.9632f);
        selectedCanvas.GetComponent<Canvas>().enabled = true;

        otherPage1.transform.localScale = new Vector3(0, 0, 0);
        otherCanvas1.GetComponent<Canvas>().enabled = false;

        otherPage2.transform.localScale = new Vector3(0, 0, 0);
        otherCanvas2.GetComponent<Canvas>().enabled = false;


        //otherPage1.SetActive(false);
       // otherPage2.SetActive(false);

    }

    
}
