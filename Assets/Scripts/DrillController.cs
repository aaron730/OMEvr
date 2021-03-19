using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DrillController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform drillTransform;
    public AudioSource drillContactSound;
    public AudioSource turnOnDrill;
    private bool startDrill = false;
    private bool buttonPressed = false;
    void Start()
    {
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
    }

    private void FixedUpdate()
    {
        
    }

   



    public void OnPress(Hand hand)
    {
        turnOnDrill.Play();
        buttonPressed = true;

        StartCoroutine(playDrillContactDelaySound());
      
    
    }

    public IEnumerator playDrillContactDelaySound()
    {
        yield return new WaitForSeconds(1);
        drillContactSound.Play();

    }
}
