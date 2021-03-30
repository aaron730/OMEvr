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

    public override void DrawHUD()
    {
        GUILayout.Label(string.Format("Hello"));
    }
}
