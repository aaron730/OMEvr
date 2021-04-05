using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketButtonController : MonoBehaviour
{
    public LaunchStation LaunchStation;

    public void ButtonLaunch()
    {
        LaunchStation.Launch();
    }
}
