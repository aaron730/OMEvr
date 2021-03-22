using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingBasketTrigger : MonoBehaviour
{
    public SortingBasket SortingBasketScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MarsRock")
        {
            MarsRock rock = other.GetComponent<MarsRock>();
            SortingBasketScript.CheckRock(rock.Type);
        }
        
    }
}
