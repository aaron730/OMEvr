using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Monitor MonitorScript;
    
    public void Scanning()
    {
        MonitorScript.DisplayText("Scanning...");
    }

    public void ScanRock(GameObject rock)
    {
        MarsRock script = rock.GetComponent<MarsRock>();
        MonitorScript.DisplayText($"Rock contains {script.Type}\n" +
            $"Weighs {script.Weight}kg");
    }

    public void RemoveRock()
    {
        MonitorScript.DisplayText("Place rock on scanner!");
    }

    public void TooManyRocks()
    {
        MonitorScript.DisplayText("Error: Too many rocks on scanner!\nRemove all rocks and try again.");
    }
}
