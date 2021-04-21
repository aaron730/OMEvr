using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMonitor : MonoBehaviour
{
    public Text MonitorText;
    private string IntroText = "Hello Astronaut ID Number 4879. Welcome to the O M V R training Simulation. In this room I’ll explain to you your objective and the basic controls. To learn about the controls, please press the button on the left. To hear about your objectives, please press the button on the right. Also feel free to interact with the objects around the room. Once you feel ready, proceed into the room behind you to begin the game.";
    private string ControlText = "To teleport, you can simply press down on the touchpad and point your controller towards where you would like to teleport. To pick up an object, simply hold down the right trigger. When you come to a remote, use the touchpad as a joystick.";
    private string ObjectiveText = "While you are on mars you will be conducting experiments to further our understanding of extraterrestrial living. Your expertise in geology, biology, geography, and many other scientific fields will be vital to your success. You will have a variety of tasks you must complete that will be sent from mission control. You can check the status of your tasks on the main monitor similar to the one you are reading off right now. Once you complete these tasks your time on mars will be finished. ";
    public AudioSource Intro;
    public AudioSource Control;
    public AudioSource Objective;

    private Coroutine current;
    private Coroutine control;
    private Coroutine objective;
    private void Start()
    {
        StartCoroutine(Display(IntroText));
        Intro.Play();
    }

    public void DisplayControlText()
    {
        StopAllCoroutines();
        Intro.Stop();
        Objective.Stop();
        StartCoroutine(Display(ControlText));
        Control.Play();
    }

    public void DisplayObjectiveText()
    {
        StopAllCoroutines();
        Intro.Stop();
        Control.Stop();
        StartCoroutine(Display(ObjectiveText));
        Objective.Play();
    }

    public IEnumerator Display(string text)
    {
        int count = 0;
        int max = text.Length;
        bool displaying = true;
        MonitorText.text = "";
        while (displaying)
        {
            if (text[count].Equals('.'))
            {
                MonitorText.text = MonitorText.text + "\n";
            }
            else
            {
                MonitorText.text = MonitorText.text + text[count];
            }
            count++;
            if (count > text.Length - 1)
            {
                displaying = false;
            }
            yield return new WaitForSeconds(Random.Range(.05f, .07f));
        }
    }


}
