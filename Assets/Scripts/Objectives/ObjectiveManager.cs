// Add this script to the GoalManager GameObject. It keeps track of all goals.
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{

    public Objective[] objectives;
    
    
    void Awake()
    {

        
        objectives = GetComponents<Objective>();
        
        
    }

    void OnGUI()
    {
        foreach (var objective in objectives)
        {
            objective.DrawHUD();
        }
       
    }

    void Update()
    {
        

        foreach (var objective in objectives)
        {
            if (objective.IsAchieved())
            {
                objective.Complete();
                Destroy(objective);
            }
        }
    }
}

 
 
// This is the abstract base class for all goals:
public abstract class Objective : MonoBehaviour
{
    public abstract bool IsAchieved();
    public abstract void Complete();
    public abstract void DrawHUD();
}


// Add this to GoalManager to run a "collect the coins" goal:
/*public class CollectCoins : Goal
{

    public int coins = 0;
    public int requiredCoins = 50;

    public override bool IsComplete()
    {
        return (coins >= requiredCoins);
    }

    public override void Complete()
    {
        ScoreSingleton.score += 10;
    }

    public override void DrawHUD()
    {
        GUILayout.Label(string.Format("Collected {0}/{1} coins", coins, requiredCoins));
    }

    public OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.tag, "Coin"))
        {
            coins++;
            Destroy(other.gameObject);
        }
    }
}

*/
 
// Add this to GoalManager to run a "kill the enemies" goal:    

