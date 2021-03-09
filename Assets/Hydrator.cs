using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrator : MonoBehaviour
{
    
    public void HydrateBag(GameObject foodBag)
    {
        Material material = foodBag.GetComponentInChildren<Renderer>().material;
        material.SetColor("_Color", Color.red);
    }
}
