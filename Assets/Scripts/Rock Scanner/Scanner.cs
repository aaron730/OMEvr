using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public Monitor MonitorScript;
    private bool rockScanned = false;
    private MarsRock script;
    public void Scanning()
    {
        MonitorScript.DisplayText("Scanning...");
    }

    public void ScanRock(GameObject rock)
    {
        script = rock.GetComponent<MarsRock>();
        MonitorScript.DisplayText($"Rock contains {script.Type}\n" +
            $"Weighs {script.Weight}kg");
        ObjectivesManager.Instance.CompleteTask("ScanRocks", 1);

    }

    public void RemoveRock()
    {
        MonitorScript.DisplayText("Place rock on scanner!");
    }

    public void TooManyRocks()
    {
        MonitorScript.DisplayText("Error: Too many rocks on scanner!\nRemove all rocks and try again.");
    }

    public bool isRockScanned()
    {
        return rockScanned;
    }
    public MarsRock GetRock()
    {
        return script;
    }
}
