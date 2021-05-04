using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMonitor : MonoBehaviour
{
    public Text MonitorText;
    private string IntroText = "- Hello Astronaut ID Number 4879. Welcome to the O M V R training Simulation. - To learn about the controls, press the button on the left. - To hear about your objectives, press the button on the right. - Once you feel ready, proceed into the room behind you to begin the game.";
    private string ControlText = " - To teleport => Press down on the touchpad. - To pick up an object =>  Squeeze right trigger. - Remote Control => TouchPad used as Joystick ";
    private string ObjectiveText = " - While you are on mars you will be conducting experiments. - Expertise in geology, biology, geography, etc required.   - Tasks you must complete that will be sent from mission control. - Check the status of your tasks on the main monitor. - Once you complete these tasks your time on mars will be finished. ";
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
