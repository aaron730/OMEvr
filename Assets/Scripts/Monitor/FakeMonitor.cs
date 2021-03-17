using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeMonitor : MonoBehaviour
{
    public Text MonitorText;
    private string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";


    private void Start()
    {
        StartCoroutine(Display());
    }

    public IEnumerator Display()
    {
        int count = 0;
        int max = LoremIpsum.Length;
        while (true)
        {
            if (LoremIpsum[count].Equals(' '))
            {
                if (Random.value > .8)
                {
                    MonitorText.text = MonitorText.text + "\n";
                }
            }
            MonitorText.text = MonitorText.text + LoremIpsum[count];
            count++;
            if (count > LoremIpsum.Length - 1)
            {
                MonitorText.text = "";
                count = 0;
            }
            yield return new WaitForSeconds(Random.Range(.005f,.015f));
        }
    }
}
