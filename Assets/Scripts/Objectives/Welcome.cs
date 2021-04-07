using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Welcome : Objective
{

   
   
    public GameObject VRPlayer;
    public Canvas Chalkboard;
    private Collider ChalkboardCollider;
    
    private bool isViewing = false;
    private bool seenDialogue = false;
    

    void Awake()
    {
        ChalkboardCollider = Chalkboard.GetComponent<Collider>();
        
        
        

    }

   

    public override bool IsAchieved()
    {
        // return (playerStats.kills >= requiredKills);\
        if (isViewing && seenDialogue)
        {
            
            return true;
        }
        else
            return false;
    }

    public override void Complete()
    {
        // ScoreSingleton.score += 50;
        // audio.Play(trumpetSound);
    }

    public override string DrawHUD(int callNumber)
    {
        switch (callNumber)
        {
            case 1:
                return "Welcome to the Orbital Mars Experience";
                
            case 2:
                return "Your mission as the only living inhabitant of Mars is research and survival.";

            case 3:
                seenDialogue = true;
                return "In order to track your progress in completing tasks, view the whiteboard.";

            case 4:
                return " ";
            default:
                return " ";
        }
        
        
    }

    public IEnumerator DelayedUpdate()
    {
        
        yield return new WaitForSecondsRealtime(3);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            isViewing = true;
        }
    }

    public override string DrawChalkboard()
    {
        return "Come Look At The Chalkboard";

    }

}
