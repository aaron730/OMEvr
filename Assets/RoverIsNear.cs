using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverIsNear : MonoBehaviour
{
    // Start is called before the first frame update
    public RoverObjectType Type;
    public GameObject Beacon;

    public void disableBeacon()
    {
        Beacon.SetActive(false);
    }
    public enum RoverObjectType
    {
        BlockIsland,
        Opportunity,
        Glacier,
        Insight,
        Perseverance,
        Curiosity


    }

}
