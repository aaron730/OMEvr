using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerRecalibration : MonoBehaviour
{
    public Text MonitorText;
    private bool isCalibrated = false;

    public AudioSource CreakingMetal;

    public void Start()
    {
        MonitorText.text = "ERROR: TOWER NOT CALIBRATED";
    }

    public void Calibrate()
    {
        if(isCalibrated)
        {
            return;
        }
        isCalibrated = true;
        StartCoroutine(Calibrating());

    }

    public IEnumerator Calibrating()
    {
        CreakingMetal.Play();
        int timer = 10;
        while(timer > 0)
        {
            timer--;
            MonitorText.text = $"<color=yellow>Calibrating...[{timer}]</color>";
            yield return new WaitForSeconds(1f);
        }
        CreakingMetal.Stop();
        ObjectivesManager.Instance.CompleteTask("RepairTower", 1);
        MonitorText.text = "<color=green>TOWER CALIBRATED</color>";
    }
}
