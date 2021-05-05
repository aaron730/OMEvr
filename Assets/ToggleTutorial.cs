using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTutorial : MonoBehaviour
{
    public bool isEnabled = true;
    public GameObject Monitors;

    public void Toggle()
    {
        if (isEnabled)
        {
            isEnabled = false;
            Monitors.SetActive(false);
        }
        else
        {
            isEnabled = true;
            Monitors.SetActive(true);
        }
    }


}
