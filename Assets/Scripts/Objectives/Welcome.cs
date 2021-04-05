using UnityEngine;

public class Welcome : Objective
{

    public GameObject chalkboard;
    public GameObject objective;
    
    
    private bool isViewing = false;
    private bool seenDialogue = false;

    void Awake()
    {
        objective.transform.position = chalkboard.transform.position;
        
        // playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        

    }

    public override bool IsAchieved()
    {
        // return (playerStats.kills >= requiredKills);\
        if (isViewing && seenDialogue)
            return true;
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
                return "Your mission as the only living inhabitant of Mars is research and survival.;";

            case 3:
                seenDialogue = true;
                return "In order to track your progress in completing tasks, view the whiteboard.";

            case 4:
                return "";
            default:
                return "";
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {

        isViewing = true;
    }
}
