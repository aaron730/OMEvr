using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingtext : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;

    public float speed = 200f;
    public Text text;
    public Text textNormal;
    public Image inner;

    public Pressurized pressurized;

    float r = 0.2f, g = 0.3f, b = 0.7f, a = 0.6f;


    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
        text.color = UnityEngine.Color.green;
        textNormal.color = Color.green;
        imageComp.color = Color.red;
        inner.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
        int a = 0;
        if (imageComp.fillAmount != 1f && !pressurized.Pressureized)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            a = (int)(imageComp.fillAmount * 100);
            if (a > 0 && a <=100 )
            {
                textNormal.text = "Changing Pressure";
                text.color = UnityEngine.Color.red;
                textNormal.color = Color.red;
                imageComp.color = Color.red;
                inner.color = Color.white;
            }

            else {
                textNormal.text = "Ready for Use";
                text.color = UnityEngine.Color.green;
                textNormal.color = Color.green;
                


            }
            text.text = a + "%";
        }
        else
        {
            imageComp.fillAmount = 0.0f;
            text.text = "";
            textNormal.text = "Ready for Use";
            text.color = UnityEngine.Color.green;
            textNormal.color = Color.green;
            text.color = UnityEngine.Color.green;
            textNormal.color = Color.green;
            imageComp.color = Color.green;
            inner.color = Color.green;
        }
    }
}
