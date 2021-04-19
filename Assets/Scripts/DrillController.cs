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
    public AudioSource DrillSoundLoop;
    
    public AudioClip turnOnDrill;
    public List<GameObject> RockPrefabs;
    public Transform RockSpawnPoint;
    private bool startDrill = false;
    private bool buttonPressed = false;
    private Vector3 drillDefaultLocation;
    public GameObject drillParticleEffects;
    void Start()
    {
        drillDefaultLocation = drillTransform.position;
        Drill.loop = true;
        drillParticleEffects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (buttonPressed)
        {
            drillTransform.Rotate(0f, -1f, 0f);


            if (drillTransform.position.y >= 0)
            {
                drillTransform.Translate(0f, -.001f, 0f);


            }



        }
        else if (!buttonPressed && drillTransform.position != drillDefaultLocation)
        {
            drillTransform.Rotate(0f, -1f, 0f);



            drillTransform.Translate(0f, .001f, 0f);
        }


        if(drillTransform.position == drillDefaultLocation)
        {
            DrillSoundLoop.Stop();
            drillParticleEffects.SetActive(false);
        }
    }

    public void OnPress(Hand hand)
    {
        if (buttonPressed == false)
        {
            DrillSoundLoop.Play();
            
            buttonPressed = true;

            StartCoroutine(DrillDelay());
        }
        else
        {
            buttonPressed = false;
            Drill.Stop();
            drillParticleEffects.SetActive(false);
        }
    
    }

    public void SpawnRocks()
    {
        StartCoroutine(SpawnRock(20));
    }

    public IEnumerator SpawnRock(int numberOfRocks)
    {
        System.Random rnd = new System.Random();
        GameObject toSpawn = RockPrefabs[rnd.Next(0, RockPrefabs.Count)];
        var force = 45;
        while (numberOfRocks > 0)
        {
            var rock = Instantiate(toSpawn, RockSpawnPoint.position, Quaternion.identity);
            var rb = rock.GetComponent<Rigidbody>();
            var rockScript = rock.GetComponent<MarsRock>();
            rockScript.RandomizeTypeAndWeight();
            rb.AddForce(rnd.Next(-force, force), rnd.Next(0, force), rnd.Next(-force, force));
            numberOfRocks--;
            yield return new WaitForSeconds(.1f);
        }
    }

    public IEnumerator DrillDelay()
    {
        yield return new WaitForSecondsRealtime(11);
        
        drillParticleEffects.SetActive(true);
        SpawnRocks();


        yield return new WaitForSecondsRealtime(8);
        buttonPressed = false;
        
        

        yield return new WaitForSecondsRealtime(5);

        drillParticleEffects.SetActive(false);

        yield return null;

    }
}
