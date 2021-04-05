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
    private float capacity = 20;

    public void Start()
    {
        MassText.text = $"Mass: {0}kg / {capacity}kg";
    }

    public void Correct(GameObject rock)
    {
        SetLightColor(Color.green);
        addMass(rock.GetComponent<MarsRock>().Weight);
    }

    public void Incorrect(GameObject rock)
    {
        SetLightColor(Color.red);
    }

    public bool CanAddMass(float mass)
    {
        return !(totalMass + mass > capacity);
    }

    public void addMass(float mass)
    {
        if (CanAddMass(mass))
        {
            totalMass += mass;
            MassText.text = $"Mass: {totalMass}kg / {capacity}kg";
        }
        else
        {
            StartCoroutine(TextColorTimer(MassText, Color.red));
            SetLightColor(Color.yellow);
        }
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
        yield return new WaitForSeconds(1);
        SetLightColor(Color.gray);
    }

}
