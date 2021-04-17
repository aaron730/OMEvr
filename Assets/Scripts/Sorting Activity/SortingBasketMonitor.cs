using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingBasketMonitor : MonoBehaviour
{
    public Text MassText;
    public Text TotalMassSentText;
    public GameObject RightLight;
    public GameObject LeftLight;

    private float totalMass = 0;
    private float capacity = 20;
    private float totalMassSent = 0;

    public AudioSource CorrectSound;
    public AudioSource IncorrectSound;

    public void Start()
    {
        MassText.text = $"Mass: {0}kg / {capacity}kg";
        TotalMassSentText.text = $"Total Mass Sent to Oribter: {0}kg";
    }

    public void Correct(GameObject rock)
    {
       // CorrectSound.Play();
        SetLightColor(Color.green);
        addMass(rock.GetComponent<MarsRock>().Weight);
    }

    public void Incorrect(GameObject rock)
    {
        //IncorrectSound.Play();
        SetLightColor(Color.red);
    }

    public void SortingLaunch()
    {
        totalMassSent += totalMass;
        totalMass = 0;
        MassText.text = $"Mass: {totalMass}kg / {capacity}kg";
        TotalMassSentText.text = $"Total Mass Sent to Oribter: {totalMassSent}kg";
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
