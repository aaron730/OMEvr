using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour
{
    public static ObjectivesManager Instance { get; private set; }
    public List<Objective> Objectives;

    public Text ObjectivesBoardText;
    public Text TasksCompleteText;

    public bool AllObjectivesComplete;

    public GameObject EndGameButton;

    //Code to ensure only one Objective Manager exists in a scene
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        Objectives = new List<Objective>();

        //Populates list of Objectives
        CreateObjectives();
        DrawObjectives();
    }

    //This is where objects get defined
    public void CreateObjectives()
    {
        Objectives.Add(new Objective
        {
            Name = "ScanRocks",
            Description = "Scan 5 Martian Rocks.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 5
        });

        Objectives.Add(new Objective
        {
            Name = "UseAirlock",
            Description = "Use the Airlock.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });

        Objectives.Add(new Objective
        {
            Name = "LaunchRocket",
            Description = "Launch 10kg of sorted rocks into space.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 10
        });

        

        Objectives.Add(new Objective
        {
            Name = "GlacierSample",
            Description = "Use the hammer to recover an ice sample from the glacier.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });

        Objectives.Add(new Objective
        {
            Name = "PlaceIceOnMicroscope",
            Description = "Place the ice you've recovered on the microscope.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });
        Objectives.Add(new Objective
        {
            Name = "EatFood",
            Description = "Eat 3 pieces of food.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 3
        });
        Objectives.Add(new Objective
        {
            Name = "RepairTower",
            Description = "Recalibrate the radio on the radio tower.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });
        Objectives.Add(new Objective
        {
            Name = "Perseverance",
            Description = "Find the abandoned Perseverance Rover.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });
        Objectives.Add(new Objective
        {
            Name = "Insight",
            Description = "Find the abandoned Insight Rover.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });
        Objectives.Add(new Objective
        {
            Name = "Opportunity",
            Description = "Find the abandoned Opportunity Rover.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });
        Objectives.Add(new Objective
        {
            Name = "BlockIsland",
            Description = "Find the Block Island meteorite.",
            IsComplete = false,
            NumberDone = 0,
            NumberNeededToComplete = 1
        });

    }

    public void DrawObjectives()
    {
        string toReturn = "";
        foreach (Objective obj in Objectives)
        {
            string toAppend = 
                $"[{(obj.IsComplete ? "X" : "-")}] " +
                $"({obj.NumberDone} / {obj.NumberNeededToComplete}) " +
                $"{obj.Description}\n";

            //Sets color to green if complete;
            if (obj.IsComplete)
            {
                toAppend = $"<color=green>{toAppend}</color>"; 
            }
            toReturn += toAppend;
        }
        ObjectivesBoardText.text = toReturn;

        if (CheckObjectivesCompleted())
        {
            TasksCompleteText.text = "ALL TASKS COMPLETED";
            EndGameButton.SetActive(true);
            AllObjectivesComplete = true;
        }
    }

    //Returns Objective object based on provided name. Returns null and throws error if no objective is found.
    public Objective GetObjective(string objName)
    {
        foreach(Objective obj in Objectives)
        {
            if(obj.Name == objName)
            {
                return obj;
            }
        }

        Debug.LogError($"Objective with name {objName} not found. Double check spelling.");
        return null;
    }

    //This function is called by outside scripts to complete tasks.
    public void CompleteTask(string objName, int amount)
    {
        Objective obj = GetObjective(objName);

        //Returns if task is already complete or can't be found
        if (obj is null || obj.IsComplete)
        {
            return;
        }

        obj.Increment(amount);

        DrawObjectives();
    }

    //Checks if given task name is complete
    public bool CheckIfSpecificTaskIsComplete(string objName)
    {
        foreach (Objective obj in Objectives)
        {
            if (obj.Name == objName)
            {
                return obj.IsComplete;
            }
        }

        Debug.LogError($"Objective with name {objName} not found. Check spelling");
        return false;
    }

    //Checks if all tasks are done
    public bool CheckObjectivesCompleted()
    {
        foreach(Objective obj in Objectives)
        {
            if (!obj.IsComplete)
            {
                return false;
            }
        }
        return true;
    }

}
