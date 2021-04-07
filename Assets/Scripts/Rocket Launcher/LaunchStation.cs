using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchStation : MonoBehaviour
{
    public Rocket Rocket;
    public RocketMonitor RocketMonitor;
    public SortingBasketMonitor SortingBasketMonitor;

    private bool InLaunchSequence = false;

    public void Launch()
    {
        if (!Rocket.IsLaunched && !InLaunchSequence)
        {
            StartCoroutine(CountDown());
        }
    }

    public void DepositRocks()
    {
        SortingBasketMonitor.SortingLaunch();
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
        DepositRocks();
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
            string str = time.ToString(@"hh\:mm\:ss");
            timer--;
            RocketMonitor.SetText("Returning in: \n"+str);
            yield return new WaitForSeconds(1);
        }
        RocketMonitor.SetText("Reentering Atmosphere");
        Rocket.Return();
        timer = 12;
        while(timer >= 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }
        RocketMonitor.SetText("Ready for Launch");
        Rocket.Realign();
        Rocket.IsLaunched = false;
    }
}
