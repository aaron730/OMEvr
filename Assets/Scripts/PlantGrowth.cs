using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public DayCycleController timeOfDayCycle;
    


    private double timeOfDay;
    private MeshFilter plantMeshFilter;
    private Mesh plantMesh;
    public Mesh[] growthStages; 

    [SerializeField]
    public GameObject plant;
    public int growthStage;


    private int growthStageBeginning = 0;



    private double[] growthStageInHoursOfDay;

    // Start is called before the first frame update
    void Start()
    {
        growthStageInHoursOfDay = new double[5];
        

        plantMeshFilter = plant.GetComponent<MeshFilter>();
        plantMesh = plantMeshFilter.mesh;
        plantMesh.MarkDynamic();

        for (int i = 1; i <= 5; i++)
        {
          //times 24.6597 by n to divide into n days(longer day cycle)
            growthStageInHoursOfDay[i-1] = Math.Round((float)(24.6597 / i),2);
            Debug.Log(growthStageInHoursOfDay[i - 1]);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
        
            
            
            
        

    }

    private void FixedUpdate()
    {
        timeOfDay = Math.Round(timeOfDayCycle.getTimeOfDay(), 2);

        for (int i = 1; i <= 5; i++)
        {
            //  Debug.Log(Mathf.FloorToInt(timeOfDay / (float)growthStageInHoursOfDay[i]));
            // Debug.Log(growthStageInHoursOfDay[i]);
            if (timeOfDay == growthStageInHoursOfDay[i-1])
            {
                plantMeshFilter.mesh = growthStages[i];

            }
        }

    }
}
