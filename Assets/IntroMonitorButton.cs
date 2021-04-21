using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMonitorButton : MonoBehaviour
{
    public IntroMonitor iMontior;
    // Start is called before the first frame update
    public void playControls()
    {
        iMontior.DisplayControlText();
    }

    public void playObjectives()
    {
        iMontior.DisplayObjectiveText(); 
    }
}
