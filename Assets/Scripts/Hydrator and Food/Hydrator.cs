using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hydrator : MonoBehaviour
{

    public GameObject AttatchedBag;
    public Text MachineText;
    
    public void HydrateBag(GameObject foodBag)
    {
        AttatchedBag = foodBag;
        /*
        Material material = foodBag.GetComponentInChildren<Renderer>().material;
        material.SetColor("_Color", Color.red);
        */
        StartCoroutine(Inflate(5));
    }

    public void DetatchBag()
    {
        AttatchedBag = null;
        MachineText.text = "Attatch Dehydrated Bag To Nozzle";
    }

    private void UpdateMachineText(float time)
    {
        MachineText.text = "Hydrating..." + time.ToString("0.00");
    }

    private IEnumerator Inflate(int time)
    {
        //Time scale is number of ticks per second bag inflates;
        float timeScale = 24;

        Vector3 scale = AttatchedBag.transform.localScale;

        float increment = (.6f - AttatchedBag.transform.localScale.y) / (5*timeScale);
        float counter = time * timeScale;
        while(counter >= 0)
        {        
            AttatchedBag.transform.localScale = scale;
            scale = new Vector3(AttatchedBag.transform.localScale.x, AttatchedBag.transform.localScale.y + increment, AttatchedBag.transform.localScale.z);
            counter--;
            UpdateMachineText(counter/timeScale);
            yield return new WaitForSeconds(1/timeScale);
        }
        MachineText.text = "Ready";
        AttatchedBag.GetComponent<FoodBag>().SetHydration(true);
        //AttatchedBag.GetComponent<Rigidbody>().isKinematic = false;
    }
}
