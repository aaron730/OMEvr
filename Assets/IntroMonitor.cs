using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMonitor : MonoBehaviour
{
    public Text MonitorText;
    private string IntroText = "Welcome Astronaut 4865417 to the OME training Simulation. Here I will explain your situation and your tasks while you get acquainted with some of the objects you will be interacting with. Feel free to move around and interact with your surroundings. While you are on mars you will be conducting experiments to further our understanding of extraterrestrial living. Your expertise in geology, biology, geography, and many other scientific fields will be vital to your success. You will also need to coordinate with Astronaut 4561687 who is stationed in an orbital module to relay information back to earth. You can communicate with them via the communication terminals. You will have a variety of tasks you must complete that will be sent from mission control. You can check the status of your tasks on the main monitor similar to the one you are reading off right now. Once you complete these tasks your time on mars will be finished. Once you are ready please proceed to the terminal to end the training simulation.";


    private void Start()
    {
        StartCoroutine(Display());
    }

    public IEnumerator Display()
    {
        int count = 0;
        int max = IntroText.Length;
        bool displaying = true;
        while (displaying)
        {
            if (IntroText[count].Equals('.'))
            {
                MonitorText.text = MonitorText.text + "\n";
            }
            MonitorText.text = MonitorText.text + IntroText[count];
            count++;
            if (count > IntroText.Length - 1)
            {
                displaying = false;
            }
            yield return new WaitForSeconds(Random.Range(.009f, .055f));
        }
    }
}
