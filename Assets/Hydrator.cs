using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrator : MonoBehaviour
{

    private GameObject AttatchedBag;
    
    public void HydrateBag(GameObject foodBag)
    {
        AttatchedBag = foodBag;
        Material material = foodBag.GetComponentInChildren<Renderer>().material;
        material.SetColor("_Color", Color.red);
        Hydrate();
    }

    private void Hydrate()
    {
        StartCoroutine(Inflate(5));
    }

    private IEnumerator Inflate(int time)
    {
        //Time scale is number of ticks per second bag inflates;
        float timeScale = 24;

        Vector3 scale = AttatchedBag.transform.localScale;

        float increment = (1 - AttatchedBag.transform.localScale.y) / (5*timeScale);
        float counter = time * timeScale;
        while(counter >= 0)
        {        
            AttatchedBag.transform.localScale = scale;
            scale = new Vector3(AttatchedBag.transform.localScale.x, AttatchedBag.transform.localScale.y + increment, AttatchedBag.transform.localScale.z);
            counter--;
            yield return new WaitForSeconds(1/timeScale);
        }
        AttatchedBag.GetComponent<FoodBag>().IsHydrated = true;
        AttatchedBag.GetComponent<Rigidbody>().isKinematic = false;
    }
}
