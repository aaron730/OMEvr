using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        FoodBag script = other.gameObject.GetComponent<FoodBag>();
        if(script == null)
        {
            return;
        }

        script.OpenBag();
    }
}
