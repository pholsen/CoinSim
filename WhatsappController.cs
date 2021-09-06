using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WhatsappController : MonoBehaviour
{

    [SerializeField] private bool isMesaj1;
    [SerializeField] private bool isMesaj2;
    [SerializeField] private bool isMesaj3;

    [SerializeField] private Sprite newSprite1;
    [SerializeField] private Sprite newSprite2;
    [SerializeField] private Sprite newSprite3;


    public void mesaj1()
    {
        isMesaj1 = true;

    }
    public void mesaj2()
    {

        isMesaj2 = true;
    }

   public void mesaj3()
    {
        isMesaj3 = true;

    }
    private void Start()
    {
        GameObject.Find("Mesaj1").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Mesaj2").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Mesaj3").transform.localScale = new Vector3(1, 1, 1);

        GameObject.Find("MehmetMesaj").GetComponent<Image>().enabled = true;
        isMesaj1 = false;
    }
    void Update()
    {
        if (isMesaj1 == true)
        {
            GameObject.Find("Mesaj1").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Mesaj2").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("Mesaj3").transform.localScale = new Vector3(1, 1, 1);
            
            GameObject.Find("MehmetMesaj").GetComponent<Image>().enabled = true;
            GameObject.Find("GalericiMesaj").GetComponent<Image>().enabled = false;
            GameObject.Find("TefeciMesaj").GetComponent<Image>().enabled = false;

            GameObject.Find("WhatsApp").GetComponent<SpriteRenderer>().sprite = newSprite1;
            isMesaj1 = false;

        }
        if(isMesaj2 == true)
        {
            GameObject.Find("Mesaj2").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Mesaj1").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("Mesaj3").transform.localScale = new Vector3(1, 1, 1);

            GameObject.Find("TefeciMesaj").GetComponent<Image>().enabled = true;
            GameObject.Find("GalericiMesaj").GetComponent<Image>().enabled = false;
            GameObject.Find("MehmetMesaj").GetComponent<Image>().enabled = false;
            GameObject.Find("WhatsApp").GetComponent<SpriteRenderer>().sprite = newSprite2;
            isMesaj2 = false;

        }
        if (isMesaj3==true)
        {
            GameObject.Find("Mesaj3").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Mesaj2").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("Mesaj1").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("TefeciMesaj").GetComponent<Image>().enabled = false;
            GameObject.Find("GalericiMesaj").GetComponent<Image>().enabled = true;
            GameObject.Find("MehmetMesaj").GetComponent<Image>().enabled = false;

            GameObject.Find("WhatsApp").GetComponent<SpriteRenderer>().sprite = newSprite3;
            isMesaj3 = false;
        }
    }
}
