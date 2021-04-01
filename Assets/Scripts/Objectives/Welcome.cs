using UnityEngine;

public class Welcome : Objective
{

   

    

    void Awake()
    {
        // playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }

    public override bool IsAchieved()
    {
        // return (playerStats.kills >= requiredKills);\
        return true;
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
                return "Your mission as the only living inhabitant of Mars is research and survival.;";

            case 3:
                return "In order to track your progress in completing tasks, view whiteboard.";

        }
        string stringDisplay;
        stringDisplay = "Hello Welcome to the Orbital Mars Experience";
        return stringDisplay;
    }
}
