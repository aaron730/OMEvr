using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeStationMonitor : MonoBehaviour
{
    public Text MonitorText;
    public void Start()
    {
        StartCoroutine(thing());
    }
    public IEnumerator thing()
    {
        while (true)
        {
            MonitorText.text = "Recalculating...";
            yield return new WaitForSeconds(5);
            MonitorText.text = "9999 Years";
            yield return new WaitForSeconds(3);
        }
    }
}
