using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DrillController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform drillTransform;
    public AudioSource Drill;
    public AudioClip drillContactSound;
    public AudioClip turnOnDrill;
    private bool startDrill = false;
    private bool buttonPressed = false;
    private Vector3 drillDefaultLocation;
    void Start()
    {
        drillDefaultLocation = drillTransform.position;
        Drill.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            drillTransform.Rotate(0f, -1f, 0f);


            if (drillTransform.position.y >= 0)
            {
                drillTransform.Translate(0f, -.001f, 0f);


            }

            

        }
        else if(!buttonPressed && drillTransform.position != drillDefaultLocation)
        {
            drillTransform.Rotate(0f, -1f, 0f);


            
                drillTransform.Translate(0f, .001f, 0f);


            
        }
    }

    private void FixedUpdate()
    {
        
    }

   



    public void OnPress(Hand hand)
    {
        if (buttonPressed == false)
        {
            Drill.PlayOneShot(turnOnDrill);
            
            buttonPressed = true;

            StartCoroutine(playDrillContactDelaySound());
        }
        else
        {
            buttonPressed = false;
            Drill.Stop();
        }
    
    }

    public IEnumerator playDrillContactDelaySound()
    {
        yield return new WaitForSeconds(5);
        Drill.PlayOneShot(drillContactSound);

    }
}
