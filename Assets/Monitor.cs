using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    public Text MonitorText;

    private void Start()
    {
        
    }

    public void SetText(string text)
    {
        MonitorText.text = text;
    }

    public void DisplayText(string text)
    {
        StartCoroutine(Print(text));
    }

    private IEnumerator Print(string text)
    {
        int textLength = text.Length;
        int count = 0;
        while(count < textLength)
        {
            MonitorText.text = MonitorText.text + text[count];
            count++;
            yield return new WaitForSeconds(.01f);
        }
    }
}
