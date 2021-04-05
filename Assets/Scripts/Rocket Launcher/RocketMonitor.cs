using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketMonitor : MonoBehaviour
{
    public Text ScreenText;

    public void SetText(string text)
    {
        ScreenText.text = text;
    }
}
