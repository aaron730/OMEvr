using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoverBase : MonoBehaviour
{
    
   // public Text MassText;
    //public Text TotalMassSentText;
    public GameObject RightLight;
    public GameObject LeftLight;
    public Rover Rover;
    public Text FoundText;
    //private float totalMass = 0;
   // private float capacity = 20;
    //private float totalMassSent = 0;

    public void Start()
    {
        //MassText.text = $"Mass: {0}kg / {capacity}kg";
        //TotalMassSentText.text = $"Total Mass Sent to Oribter: {0}kg";
    }


    public void OnObjectFind(string objectName)            
    {
        SetLightColor(Color.green);
        FoundText.text = (objectName + " Found");
        Invoke("ReturnToSearching", 3f);
    }

    public void ReturnToSearching()
    {
        FoundText.text = "...Searching";
    }

    public void SetLightColor(Color color)
    {
        RightLight.GetComponent<Renderer>().material.SetColor("_BaseColor", color);
        LeftLight.GetComponent<Renderer>().material.SetColor("_BaseColor", color);
        StopCoroutine(LightTimer());
        StartCoroutine(LightTimer());
    }

    public IEnumerator TextColorTimer(Text text, Color color)
    {
        Color originalColor = text.color;
        Debug.Log($"Origina color is {originalColor}");
        text.color = color;
        yield return new WaitForSeconds(1);
        text.color = originalColor;
        Debug.Log($"Current color {text.color}");
    }

    public IEnumerator LightTimer()
    {
        yield return new WaitForSeconds(3);
        SetLightColor(Color.gray);
    }
}
