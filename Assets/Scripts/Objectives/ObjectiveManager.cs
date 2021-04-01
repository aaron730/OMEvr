// Add this script to the GoalManager GameObject. It keeps track of all goals.
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{

    public Objective[] objectives;
    
    public Canvas VRCanvas;
    public Canvas TwoDCanvas;
    private Text VRText;
    private Text TwoDText;
    
    void Awake()
    {
        
        VRText = VRCanvas.GetComponentInChildren<Text>();
        TwoDText = TwoDCanvas.GetComponentInChildren<Text>();

        TwoDText.text = "Hello";
        TwoDText.horizontalOverflow = HorizontalWrapMode.Overflow;
        VRText.horizontalOverflow = HorizontalWrapMode.Overflow;
        objectives = GetComponents<Objective>();
        
        
    }

    private IEnumerator Delay(int i)
    {
        yield return new WaitForSecondsRealtime(i);
    }
    
    void OnGUI()
    {
        foreach (var objective in objectives)
        {
            for(int i = 0; i <= 5; i++)
            {
                TwoDText.text = objective.DrawHUD(i);
                VRText.text = objective.DrawHUD(i);
                Delay(3);
            }
           
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
    public abstract string DrawHUD(int callNumber);
}



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

