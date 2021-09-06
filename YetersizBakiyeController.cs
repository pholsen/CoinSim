using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YetersizBakiyeController : MonoBehaviour
{
    public bool isYetersiz;




    public Image Yetersiz;
    void Start()
    {

        Yetersiz.transform.localScale = new Vector3(0, 0, 0);


    }

    
    void Update()
    {
        if (isYetersiz == true)
        {
            Yetersiz.transform.localScale = new Vector3(1, 1, 1);
            Yetersiz.canvasRenderer.SetAlpha(1.0f);
            Yetersiz.CrossFadeAlpha(0,1,false);

            isYetersiz = false;
        }
    }
}
