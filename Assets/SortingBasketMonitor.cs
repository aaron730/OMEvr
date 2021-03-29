using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingBasketMonitor : MonoBehaviour
{
    public Text MassText;
    public GameObject RightLight;
    public GameObject LeftLight;

    private float totalMass = 0;

    public void Correct(GameObject rock)
    {
        SetLightColor(Color.green);
        addMass(rock.GetComponent<MarsRock>().Weight);
    }

    public void Incorrect(GameObject rock)
    {
        SetLightColor(Color.red);
    }

    public void addMass(float mass)
    {
        totalMass += mass;
        MassText.text = "Mass: " + totalMass.ToString() + "kg";
    }

    public void SetLightColor(Color color)
    {
        RightLight.GetComponent<Renderer>().material.SetColor("_BaseColor", color);
        LeftLight.GetComponent<Renderer>().material.SetColor("_BaseColor", color);
        StopAllCoroutines();
        StartCoroutine(LightTimer());
    }

    public IEnumerator LightTimer()
    {
        yield return new WaitForSeconds(1);
        SetLightColor(Color.gray);
    }

}
