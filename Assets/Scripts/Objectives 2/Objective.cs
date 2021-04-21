using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective
{
    public string Name;
    public string Description;
    public bool IsComplete;
    public float NumberDone;
    public float NumberNeededToComplete;

    public void Increment(int num)
    {
        NumberDone += num;
        if(NumberDone >= NumberNeededToComplete)
        {
            IsComplete = true;
        }
    }

    public void CompleteTask()
    {
        IsComplete = true;
    }
}
