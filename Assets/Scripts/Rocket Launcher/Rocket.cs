using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rb;
    public bool IsLaunched;
    public AudioSource LaunchSound;

    private Vector3 localPos;

    public void Start()
    {
        localPos = transform.localPosition;
        IsLaunched = false;
        rb = GetComponent<Rigidbody>();
    }
    public void Launch()
    {
        StartCoroutine(LaunchSequence());
    }

    public void Return()
    {
        EnableRocket();
    }

    public void Realign()
    {
        rb.velocity = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        transform.localPosition = localPos;      
    }

    public void DisableRocket()
    {
        rb.isKinematic = true;
        MeshRenderer[] list = GetComponentsInChildren<MeshRenderer>();
        foreach( MeshRenderer x in list)
        {
            x.enabled = false;
        }
        
    }

    public void EnableRocket()
    {
        rb.isKinematic = false;
        MeshRenderer[] list = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer x in list)
        {
            x.enabled = true;
        }
    }

    public IEnumerator LaunchSequence()
    {
        IsLaunched = true;
        LaunchSound.Play();
        var timer = 3;
        //transform.eulerAngles = Vector3.zero;
        while (timer > 0)
        {
            Debug.Log(timer);
            rb.AddForce(Vector3.up * 90000);
            timer--;
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(7);
        DisableRocket();
    }
}
