using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScanner : MonoBehaviour
{
    public Monitor MonitorScript;


    public void ScanRock(GameObject rock)
    {
       IntroItem script = rock.GetComponent<IntroItem>();
        MonitorScript.DisplayText("This is a " + script.Type);
    }

    public void Scanning()
    {
        MonitorScript.DisplayText("Scanning...");
    }

    public void RemoveRock()
    {
        MonitorScript.DisplayText("Place object on scanner!");
    }

    public void TooManyRocks()
    {
        MonitorScript.DisplayText("Error: Too many objects on scanner!\nRemove all objects and try again.");
    }
}


