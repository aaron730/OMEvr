using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchStation : MonoBehaviour
{
    public Rocket Rocket;
    public RocketMonitor RocketMonitor;

    private bool InLaunchSequence = false;

    public void Launch()
    {
        if (!Rocket.IsLaunched && !InLaunchSequence)
        {
            StartCoroutine(CountDown());
        }
    }

    public IEnumerator CountDown()
    {
        InLaunchSequence = true;
        var timer = 10;
        while(timer >= 0)
        {
            RocketMonitor.SetText(timer.ToString());
            timer--;
            yield return new WaitForSeconds(1);
        }
        RocketMonitor.SetText("Ignition");
        Rocket.Launch();
        InLaunchSequence = false;
        yield return new WaitForSeconds(5);
        StartCoroutine(ReturnCountDown());
    }

    public IEnumerator ReturnCountDown()
    {
        int timer = 20;
        while(timer >= 0)
        {

            TimeSpan time = TimeSpan.FromSeconds(timer);
            string str = time.ToString(@"hh\:mm\:ss\:fff");
            timer--;
            RocketMonitor.SetText(str);
            yield return new WaitForSeconds(1);
        }
        RocketMonitor.SetText("Returned");
        Rocket.Return();
    }
}
