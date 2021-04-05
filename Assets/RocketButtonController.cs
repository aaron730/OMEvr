using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketButtonController : MonoBehaviour
{
    public Rocket Rocket;

    public void ButtonLaunch()
    {
        if (!Rocket.IsLaunched)
        {
            Rocket.Launch();
        }

    }
}
