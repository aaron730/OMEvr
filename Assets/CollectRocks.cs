using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class CollectRocks : Objective
{

   
    
    public GameObject VRPlayer;
    public Canvas Chalkboard;
    private Collider ChalkboardCollider;
   
    private bool isViewing = false;
    private bool seenDialogue = false;
    public Scanner RockScanner;
    private MarsRock rock;

    private bool OlivineCollected = false;
    private bool GypsumCollected = false;
    private bool BasaltCollected = false;
    private bool GeothiteCollected = false;
    void Awake()
    {
       
        ChalkboardCollider = Chalkboard.GetComponent<Collider>();
       
        
        // playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        
        

    }



    public override bool IsAchieved()
    {
        if(RockScanner.GetRock().Type.ToString() == "Olivine")
        {
            OlivineCollected = true;
            Debug.Log("Olivine");
        }
        if (RockScanner.GetRock().Type.ToString() == "Geothite")
        {
            GeothiteCollected = true;
            Debug.Log("Geothite");
        }
        if (RockScanner.GetRock().Type.ToString() == "Basalt")
        {
            BasaltCollected = true;
            Debug.Log("Basalt");
        }
        if (RockScanner.GetRock().Type.ToString() == "Gypsum")
        {
            GypsumCollected = true;
            Debug.Log("Gypsum");
        }

        if(OlivineCollected && GypsumCollected && GeothiteCollected && BasaltCollected)
        {
            return true;
        }
        else
        {

            return false;
        }
        StartCoroutine(Delay());
        
    }

    public override void Complete()
    {
        // ScoreSingleton.score += 50;
        // audio.Play(trumpetSound);
    }

    public bool ScanRocks()
    {
        
        return false;

    }
    
    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(3);
    }

    

    public override string DrawHUD(int callNumber)
    {
        return "";


    }

  

    public override string DrawChalkboard()
    {
        return "Scan rocks until you find: \n 1. Olivine \n 2. Gypsum \n 3. Geothite \n 4. Basalt \n ";
    }
}