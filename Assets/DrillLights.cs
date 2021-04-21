using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DrillLights : MonoBehaviour
{
    private bool buttonPressed = false;
    public GameObject drillLights;
    public AudioSource spotlightSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
        drillLights.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress(Hand hand)
    {
        
        if (buttonPressed == false)
        {
            
            spotlightSound.Play();
            drillLights.SetActive(true);
            buttonPressed = true;
        }
        else
        {
            drillLights.SetActive(false);
            buttonPressed = false;
        }

    }
}
